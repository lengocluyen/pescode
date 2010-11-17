using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace Pes.Core.Impl
{
    public class AlertService : IAlertService
    {
        private IConfiguration _configuration;
        private IUserSession _userSession;
        private IWebContext _webContext;
        private Alert alert;
        private Account account;
        private string alertMessage;
        private string[] tags = { "[rootUrl]" };

        public AlertService()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _configuration = ObjectFactory.GetInstance<IConfiguration>();
        }

        private void Init()
        {
            account = _userSession.CurrentUser;
            alert = new Alert();
            alert.AccountID = account.AccountID;
            alert.CreateDate = DateTime.Now;
        }
        private void Init(Account modifiedAccount)
        {
            account = modifiedAccount;
            alert = new Alert();
            alert.AccountID = account.AccountID;
            alert.CreateDate = DateTime.Now;
        }

        public void AddAccountCreatedAlert()
        {
            Init();
            alertMessage = GetProfileImage(account.AccountID) + "<div class='title'><h2>" + GetProfileUrl(account.Username) + "</h2></div> vừa đăng nhập!";
            alertMessage += "<div class=\"body\">" + GetSendMessageUrl(account.AccountID) + "</div>";
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.AccountCreated;
            SaveAlert(alert);
        }

        public void AddAccountModifiedAlert(Account modifiedAccount)
        {
            Init(modifiedAccount);
            alertMessage = GetProfileImage(account.AccountID) + string.Format("<div class='title'><h2>{0} </h2></div> cập nhật thông tin tài khoản.",
                                    GetProfileUrl(account.Username));
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.AccountModified;
            SaveAlert(alert);

        }

        public void AddProfileCreatedAlert()
        {
            Init();
            alertMessage = GetProfileImage(account.AccountID) + "<div class='title'><h2>" + GetProfileUrl(account.Username) + "</h2></div>" +
                           " vừa tạo thông tin cá nhân!";
            alertMessage += "<div class=\"body\">" + GetSendMessageUrl(account.AccountID) + "</div>";
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.ProfileCreated;
            SaveAlert(alert);
            SendAlertToFriends(alert);
        }

        public void AddProfileModifiedAlert()
        {
            Init();
            alertMessage = GetProfileImage(account.AccountID) + "<div class='title'><h2>" + GetProfileUrl(account.Username) + "</h2></div>" +
                           " cập nhật thông tin cá nhân.";
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.ProfileModified;
            SaveAlert(alert);
            SendAlertToFriends(alert);
        }

        public void AddNewAvatarAlert()
        {
            Init();
            alertMessage = GetProfileImage(account.AccountID) +
                "<div class='title'><h2>" + GetProfileImage(account.AccountID) + GetProfileUrl(account.Username) + "</h2></div>" + " cập nhật avatar.";
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.NewAvatar;
            SaveAlert(alert);
            SendAlertToFriends(alert);
        }

        /*--------------------------------------------------------------*/
        public List<Alert> GetAlertsByFriendandMe(int AccountID)
        {
            List<Alert> result = new List<Alert>();
            List<Alert> alerts = Alert.GetAlertsByAccountID(AccountID);
            foreach (Alert alert in alerts)
            {
                foreach (string s in tags)
                {
                    switch (s)
                    {
                        case "[rootUrl]":
                            alert.Message = alert.Message.Replace("[rootUrl]", _webContext.RootUrl);
                            result.Add(alert);
                            break;
                    }
                }
            }

            return result;
        }
        /*--------------------------------------------------------------*/
        public List<Alert> GetAlertsOfMeAndFriendByAccountID(int accID)
        {
            List<Alert> result = new List<Alert>();
            List<Alert> alerts = Alert.GetAlertByAccountIDofMeAndFriend(accID);
            foreach (Alert alert in alerts)
            {
                foreach (string s in tags)
                {
                    switch (s)
                    {
                        case "[rootUrl]":
                            alert.Message = alert.Message.Replace("[rootUrl]", _webContext.RootUrl);
                            result.Add(alert);
                            break;
                    }
                }
            }

            return result;
        }
        public List<Alert> GetAlertsByAccountID(int AccountID)
        {
            List<Alert> result = new List<Alert>();
            List<Alert> alerts = Alert.GetAlertsByAccountID(AccountID);
            foreach (Alert alert in alerts)
            {
                foreach (string s in tags)
                {
                    switch (s)
                    {
                        case "[rootUrl]":
                            alert.Message = alert.Message.Replace("[rootUrl]", _webContext.RootUrl);
                            result.Add(alert);
                            break;
                    }
                }
            }

            return result;
        }

        public List<Alert> GetAlertsByAccountID(int AccountID, int Skip)
        {
            List<Alert> result = new List<Alert>();
            List<Alert> alerts = Alert.GetAlertsByAccountID(AccountID, Skip);
            foreach (Alert alert in alerts)
            {
                foreach (string s in tags)
                {
                    switch (s)
                    {
                        case "[rootUrl]":
                            alert.Message = alert.Message.Replace("[rootUrl]", _webContext.RootUrl);
                            result.Add(alert);
                            break;
                    }
                }
            }

            return result;
        }

        public List<Alert> GetAlertsByAccountID(int AccountID, int currentIndex, int itemAdd)
        {
            List<Alert> result = new List<Alert>();
            List<Alert> alerts = Alert.GetAlertsByAccountID(AccountID, currentIndex, itemAdd);
            foreach (Alert alert in alerts)
            {
                foreach (string s in tags)
                {
                    switch (s)
                    {
                        case "[rootUrl]":
                            alert.Message = alert.Message.Replace("[rootUrl]", _webContext.RootUrl);
                            result.Add(alert);
                            break;
                    }
                }
            }

            return result;
        }

        /*new*/
        public void AddFriendAddedAlert(Account FriendRequestFrom, Account FriendRequestTo)
        {
            Init();
            alert = new Alert();
            //alert.CreateDate = DateTime.Now;
            alert.AccountID = FriendRequestFrom.AccountID;
            alertMessage = GetProfileImage(account.AccountID) + "<div class='title'><h2>" + GetProfileImage(FriendRequestTo.AccountID) + GetProfileUrl(FriendRequestTo.Username) + "</h2></div>" + " là bạn ngay bây giờ!";
            alertMessage += "<div class=\"body\">" + GetSendMessageUrl(FriendRequestTo.AccountID) + "</div>";
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.FriendAdded;
            SaveAlert(alert);

            alert = new Alert();
            alert.CreateDate = DateTime.Now;
            alert.AccountID = FriendRequestTo.AccountID;
            alertMessage = GetProfileImage(account.AccountID) + "<div class='title'><h2>" + GetProfileImage(FriendRequestFrom.AccountID) + GetProfileUrl(FriendRequestFrom.Username) + "</h2></div>" + " là bạn ngay bây giờ!";
            alertMessage += "<div class=\"body\">" + GetSendMessageUrl(FriendRequestFrom.AccountID) + "</div>";
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.FriendAdded;
            SaveAlert(alert);

            alert = new Alert();
            alert.CreateDate = DateTime.Now;
            alert.AlertTypeID = (int)AlertType.AlertTypes.FriendAdded;
            alertMessage = GetProfileImage(account.AccountID) + "<div class='title'><h2>" + GetProfileUrl(FriendRequestFrom.Username) + " và " +
                           GetProfileUrl(FriendRequestTo.Username) + "</h2></div>" + " làm bạn ngay bay giờ!";
            alert.Message = alertMessage;

            alert.AccountID = FriendRequestFrom.AccountID;
            SendAlertToFriends(alert);

            alert.AccountID = FriendRequestTo.AccountID;
            SendAlertToFriends(alert);
        }

        public void AddFriendRequestAlert(Account FriendRequestFrom, Account FriendRequestTo, Guid requestGuid, string Message)
        {
            Init();
            alert = new Alert();
            //alert.CreateDate = DateTime.Now;
            alert.AccountID = FriendRequestTo.AccountID;
            alertMessage = GetProfileImage(account.AccountID) + "<div class='title'><h2>" + GetProfileImage(FriendRequestFrom.AccountID) + GetProfileUrl(FriendRequestFrom.Username) + "</h2></div>" + " muốn được kết bạn!";
            alertMessage += "<div class=\"body\">";
            alertMessage += FriendRequestFrom.FirstName + " " + FriendRequestFrom.LastName +
                            " muốn là bạn của bạn!  Nhấn chuột vào liên kết để kết bạn: ";
            alertMessage += "<a href=\"" + _configuration.RootURL +
            "Friends/ConfirmFriendshipRequest.aspx?InvitationKey=" + requestGuid.ToString() + "\">" + _configuration.RootURL +
            "Friends/ConfirmFriendshipRequest.aspx?InvitationKey=" + requestGuid.ToString() + "</a><hr/>" + Message + "</div>";

            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.FriendRequest;
            SaveAlert(alert);
        }

        public long AddStatusUpdateAlert(StatusUpdate statusUpdate)
        {
            //alert = new Alert();
            //alert.CreateDate = DateTime.Now;
            //alert.AccountID = _userSession.CurrentUser.AccountID;
            //alert.AlertTypeID = (int)AlertType.AlertTypes.StatusUpdate;
            //alertMessage = "<div class=\"AlertHeader\">"
            //    + GetProfileImage(_userSession.CurrentUser.AccountID) + GetProfileUrl(_userSession.CurrentUser.Username) + " " + statusUpdate.Status + "</div>";
            //alert.Message = alertMessage;
            //SaveAlert(alert);
            //SendAlertToFriends(alert);

            Init();
            alert = new Alert();
            //alert.CreateDate = DateTime.Now;
            alert.AccountID = account.AccountID;
            alert.AlertTypeID = (int)AlertType.AlertTypes.StatusUpdate;
            alertMessage = statusUpdate.Status;
            alert.Message = GetProfileImage(account.AccountID) + "<div class='title'><h2>"
                + GetProfileUrl(account.Username) + "</h2></div>" + alertMessage;
            SaveAlert(alert);
            SendAlertToFriends(alert);
            return alert.AlertID;
        }
        public void AddBlogAlert(Blog blog)
        {

        }
        public void AddNewBoardPostAlert(BoardCategory category, BoardForum forum, BoardPost post, BoardPost thread)
        {
            throw new NotImplementedException();
        }

        public void AddNewBoardThreadAlert(BoardCategory category, BoardForum forum, BoardPost post)
        {
            throw new NotImplementedException();
        }

        public void AddNewBoardThreadAlert(BoardCategory category, BoardForum forum, BoardPost post, Group group)
        {
            throw new NotImplementedException();
        }

        public void AddNewBoardPostAlert(BoardCategory category, BoardForum forum, BoardPost post, BoardPost thread, Group group)
        {
            throw new NotImplementedException();
        }

        private void SaveAlert(Alert alert)
        {
            Alert.SaveAlert(alert);
        }

        private void SendAlertToFriends(Alert alert)
        {
            List<Friend> friends = Friend.GetFriendsByAccountID(alert.AccountID);
            foreach (Friend friend in friends)
            {
                alert.AlertID = 0;
                alert.AccountID = friend.MyFriendsAccountID;
                SaveAlert(alert);
            }
        }
        public long AddAlertToWallFriend(string Text, int FriendAccountID)
        {
            Account current = _userSession.CurrentUser;
            alertMessage = Text;
            alert = new Alert();
            alert.CreateDate = DateTime.Now;
            alert.AccountID = FriendAccountID;
            alert.AlertTypeID = (int)AlertType.AlertTypes.WriteWall;
            alert.Message = GetProfileImage(current.AccountID) + "<div class='title'><h2>"
                + GetProfileUrl(current.Username) + "</h2></div>" + alertMessage;
            SaveAlert(alert);

            List<Friend> friends = Friend.GetFriendsByAccountID(FriendAccountID);
            foreach (Friend friend in friends)
            {
                if (current.AccountID == friend.MyFriendsAccountID)
                    continue;
                alert.AlertID = 0;
                alert.AccountID = friend.MyFriendsAccountID;
                SaveAlert(alert);
            }

            return alert.AlertID;
        }

        private string GetProfileImage(Int32 AccountID)
        {
            //return "<img width=\"50\" height=\"50\" src=\"[rootUrl]images/ProfileAvatar/ProfileImage.aspx?AccountID=" +
            //    AccountID.ToString() + "&w=50&h=50\" align=\"absmiddle\">";
            string link = "[rootUrl]images/ProfileAvatar/ProfileImage.aspx?AccountID=" + AccountID.ToString();
            return "<div class='post-gravatar'>"
                + "<a href='/profiles.aspx/profile.aspx?AccountID=" + AccountID + "'>"
                + "<img width=\"50\" height=\"50\" src='" + link + "'&w=50&h=50\" align=\"absmiddle\"></a></div>";
        }
        private string GetProfileUrl(string username)
        {
            return "<a href=\"[rootUrl]" + username + "\">" + username + "</a>";
        }

        private string GetSendMessageUrl(Int32 AccountID)
        {
            return "Bấm vào đây để gửi tin nhắn";
        }
        public void AddNewBlogPostAlert(Blog blog)
        {
            Init();
            alert = new Alert();
            //alert.CreateDate = DateTime.Now;
            alert.AccountID = account.AccountID;
            alert.AlertTypeID = (int)AlertType.AlertTypes.NewBlogPost;
            alertMessage =
                      GetProfileImage(account.AccountID)
                     + "<div class='title'><h2>" + GetProfileUrl(_userSession.CurrentUser.Username) + "</h2></div>"
                     + " đã viết blog: <b><a href='[rootUrl]blogs/" + _webContext.Username + "/" + blog.PageName + ".aspx'>"
+ blog.Title + "</a></b>";
            alert.Message = alertMessage;
            SaveAlert(alert);
            SendAlertToFriends(alert);
        }
        public void AddUpdatedBlogPostAlert(Blog blog)
        {
            alert = new Alert();
            alert.CreateDate = DateTime.Now;
            alert.AccountID = account.AccountID;
            alert.AlertTypeID = (int)AlertType.AlertTypes.NewBlogPost;
            alertMessage = GetProfileImage(account.AccountID) + "<div class='title'><h2>"
                          + GetProfileUrl(_userSession.CurrentUser.Username)
                          + " </h2></div> đã cập nhật <b>" + blog.Title +
                          "!";
            alert.Message = alertMessage;
            SaveAlert(alert);
            SendAlertToFriends(alert);
        }

        #region IAlertService Members


        public List<Alert> GetAlertsByAlertID(long AlertID)
        {
            List<Alert> result = new List<Alert>();
            List<Alert> alerts = Alert.Find(x => x.AlertID == AlertID).ToList();
            foreach (Alert alert in alerts)
            {
                foreach (string s in tags)
                {
                    switch (s)
                    {
                        case "[rootUrl]":
                            alert.Message = alert.Message.Replace("[rootUrl]", _webContext.RootUrl);
                            result.Add(alert);
                            break;
                    }
                }
            }

            return result;
        }

        #endregion
    }
}
