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
            alertMessage = "<div class=\"AlertHeader\">" + GetProfileUrl(account.Username) + " vừa đăng nhập!</div>";
            alertMessage += "<div class=\"AlertRow\">" + GetSendMessageUrl(account.AccountID) + "</div>";
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.AccountCreated;
            SaveAlert(alert);
        }

        public void AddAccountModifiedAlert(Account modifiedAccount)
        {
            Init(modifiedAccount);
            alertMessage = string.Format("<div class='AlertHeader'>{0} cập nhật thông tin tài khoản.</div>",
                                    GetProfileUrl(account.Username));
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.AccountModified;
            SaveAlert(alert);

        }

        public void AddProfileCreatedAlert()
        {
            Init();
            alertMessage = "<div class=\"AlertHeader\">" + GetProfileUrl(account.Username) +
                           " vừa tạo thông tin cá nhân!</div>";
            alertMessage += "<div class=\"AlertRow\">" + GetSendMessageUrl(account.AccountID) + "</div>";
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.ProfileCreated;
            SaveAlert(alert);
            SendAlertToFriends(alert);
        }

        public void AddProfileModifiedAlert()
        {
            Init();
            alertMessage = "<div class=\"AlertHeader\">" + GetProfileUrl(account.Username) +
                           " cập nhật thông tin cá nhân.</div>";
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.ProfileModified;
            SaveAlert(alert);
            SendAlertToFriends(alert);
        }

        public void AddNewAvatarAlert()
        {
            Init();
            alertMessage =
                "<div class=\"AlertHeader\">" + GetProfileImage(account.AccountID) + GetProfileUrl(account.Username) + " cập nhật avatar .</div>";
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
            alert = new Alert();
            alert.CreateDate = DateTime.Now;
            alert.AccountID = FriendRequestFrom.AccountID;
            alertMessage = "<div class=\"AlertHeader\">" + GetProfileImage(FriendRequestTo.AccountID) + GetProfileUrl(FriendRequestTo.Username) + " là bạn ngay bây giờ!</div>";
            alertMessage += "<div class=\"AlertRow\">" + GetSendMessageUrl(FriendRequestTo.AccountID) + "</div>";
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.FriendAdded;
            SaveAlert(alert);

            alert = new Alert();
            alert.CreateDate = DateTime.Now;
            alert.AccountID = FriendRequestTo.AccountID;
            alertMessage = "<div class=\"AlertHeader\">" + GetProfileImage(FriendRequestFrom.AccountID) + GetProfileUrl(FriendRequestFrom.Username) + " là bạn ngay bây giờ!</div>";
            alertMessage += "<div class=\"AlertRow\">" + GetSendMessageUrl(FriendRequestFrom.AccountID) + "</div>";
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.FriendAdded;
            SaveAlert(alert);

            alert = new Alert();
            alert.CreateDate = DateTime.Now;
            alert.AlertTypeID = (int)AlertType.AlertTypes.FriendAdded;
            alertMessage = "<div class=\"AlertHeader\">" + GetProfileUrl(FriendRequestFrom.Username) + " và " +
                           GetProfileUrl(FriendRequestTo.Username) + " làm bạn ngay bay giờ!</div>";
            alert.Message = alertMessage;

            alert.AccountID = FriendRequestFrom.AccountID;
            SendAlertToFriends(alert);

            alert.AccountID = FriendRequestTo.AccountID;
            SendAlertToFriends(alert);
        }

        public void AddFriendRequestAlert(Account FriendRequestFrom, Account FriendRequestTo, Guid requestGuid, string Message)
        {
            alert = new Alert();
            alert.CreateDate = DateTime.Now;
            alert.AccountID = FriendRequestTo.AccountID;
            alertMessage = "<div class=\"AlertHeader\">" + GetProfileImage(FriendRequestFrom.AccountID) + GetProfileUrl(FriendRequestFrom.Username) + " muốn được kết bạn!</div>";
            alertMessage += "<div class=\"AlertRow\">";
            alertMessage += FriendRequestFrom.FirstName + " " + FriendRequestFrom.LastName +
                            " muốn là bạn của bạn!  Nhấn chuột vào liên kết để kết bạn: ";
            alertMessage += "<a href=\"" + _configuration.RootURL +
            "Friends/ConfirmFriendshipRequest.aspx?InvitationKey=" + requestGuid.ToString() + "\">" + _configuration.RootURL +
            "Friends/ConfirmFriendshipRequest.aspx?InvitationKey=" + requestGuid.ToString() + "</a><HR>" + Message + "</div>";

            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.FriendRequest;
            SaveAlert(alert);
        }

        public void AddStatusUpdateAlert(StatusUpdate statusUpdate)
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

            alert = new Alert();
            alert.CreateDate = DateTime.Now;
            alert.AccountID = _userSession.CurrentUser.AccountID;
            alert.AlertTypeID = (int)AlertType.AlertTypes.StatusUpdate;
            alertMessage = statusUpdate.Status;
            alert.Message = alertMessage;
            SaveAlert(alert);
            SendAlertToFriends(alert);
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


        private string GetProfileImage(Int32 AccountID)
        {
            return "<img width=\"50\" height=\"50\" src=\"[rootUrl]images/ProfileAvatar/ProfileImage.aspx?AccountID=" +
                AccountID.ToString() + "&w=50&h=50\" align=\"absmiddle\">";
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
            alert = new Alert();
            alert.CreateDate = DateTime.Now;
            alert.AccountID = _userSession.CurrentUser.AccountID;
            alert.AlertTypeID = (int)AlertType.AlertTypes.NewBlogPost;
            alertMessage = "<div class=\"AlertHeader\">" +
                      GetProfileImage(_userSession.CurrentUser.AccountID)
                     + GetProfileUrl(_userSession.CurrentUser.Username)
                     + " đã viết blog: <b><a href='[rootUrl]blogs/" + _webContext.Username + "/" + blog.PageName + ".aspx'>"
+ blog.Title + "</a></b></div>";
            alert.Message = alertMessage;
            SaveAlert(alert);
            SendAlertToFriends(alert);
        }
        public void AddUpdatedBlogPostAlert(Blog blog)
        {
            alert = new Alert();
            alert.CreateDate = DateTime.Now;
            alert.AccountID = _userSession.CurrentUser.AccountID;
            alert.AlertTypeID = (int)AlertType.AlertTypes.NewBlogPost;
            alertMessage = "<div class=\"AlertHeader\">" +
                          GetProfileImage(_userSession.CurrentUser.AccountID)
                          + GetProfileUrl(_userSession.CurrentUser.Username)
                          + " đã cập nhật <b>" + blog.Title +
                          "!</div>";
            alert.Message = alertMessage;
            SaveAlert(alert);
            SendAlertToFriends(alert);
        }
    }
}
