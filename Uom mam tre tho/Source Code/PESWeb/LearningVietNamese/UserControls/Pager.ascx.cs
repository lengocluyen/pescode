using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Threading;

namespace PESWeb.LearningVietNamese.UserControls
{
    public partial class UserControls_Pager : System.Web.UI.UserControl
    {

        public int totalItems;
        public int currentPage = 1;
        public int start = 1;
        public int end;

        int totalPages;
        int pageSize = 2;
        int firstPagesDisplay = 5;
        int lastPagesDisplay = 3;
        int pagesJumpNext = 5;
        int pagesJumpPrevious = 5;

        string sessionPageChanged;
        string sessionPage;


        protected override void OnInit(EventArgs e)
        {
            CalculateStartEnd();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateTotalPages();
        }

        public void UpdateTotalPages()
        {
            // ...
            Label lblDots = new Label();
            lblDots.Text = "&nbsp;...&nbsp;";
            lblDots.ID = "lblDots";


            totalPages = CalculateTotalPages();
            this.pnlPager.Controls.Clear();
            BuildAnotherElements();

            int width;
            int pageStart;
            int pageEnd;
            // First Pages
            width = firstPagesDisplay / 2;
            if (firstPagesDisplay % 2 != 0)
                pageStart = currentPage - width;
            else
                pageStart = currentPage - width + 1;

            if (pageStart < 1)
            {
                pageStart = 1;
                pageEnd = pageStart + firstPagesDisplay - 1;
            }
            else
                pageEnd = currentPage + width;

            if (pageEnd > totalPages)
                pageEnd = totalPages;

            if (pageStart > 2)
            {
                AddButton(1, 3);
                Label lblNewDots = new Label();
                lblNewDots.Text = "&nbsp;...&nbsp;";
                lblNewDots.ID = "lblNewDots";
                this.pnlPager.Controls.AddAt(4, lblNewDots);
            }

            AddButtons(pageStart, pageEnd);


            if (pageEnd < totalPages)
            {
                // Last Pages
                pageStart = totalPages - lastPagesDisplay + 1;
                if (pageEnd < pageStart - 1) // End of First Pages < Start of Last Pages            
                    this.pnlPager.Controls.Add(lblDots);
                else // End of First Pages > Start of Last Pages            
                {
                    pageStart = pageEnd + 1;
                }

                pageEnd = totalPages;

                AddButtons(pageStart, pageEnd);
            }

            if (totalPages < currentPage)
            {
                PESSession.Set(sessionPage, totalPages);
                CalculateStartEnd();
            }

            AddDropDownListJumpTo();
        }

        void AddButtons(int pageStart, int pageEnd)
        {
            for (int i = pageStart; i <= pageEnd; i++)
            {
                LinkButton lbt = new LinkButton();
                lbt.ID = i.ToString();
                lbt.Text = i.ToString() + "&nbsp;";
                if (i == currentPage)
                    lbt.ForeColor = System.Drawing.Color.Red;
                lbt.Click += new EventHandler(lbt_Click);
                this.pnlPager.Controls.Add(lbt);
            }
        }


        void AddButton(int id, int index)
        {
            LinkButton lbt = new LinkButton();
            lbt.ID = id.ToString();
            lbt.Text = id.ToString() + "&nbsp;";
            if (id == currentPage)
                lbt.ForeColor = System.Drawing.Color.Red;
            lbt.Click += new EventHandler(lbt_Click);
            this.pnlPager.Controls.AddAt(index, lbt);
        }

        void BuildAnotherElements()
        {
            // Trang
            Label lblPage = new Label();
            lblPage.Text = "Trang:&nbsp;";
            lblPage.ID = "lblPage";
            this.pnlPager.Controls.Add(lblPage);

            // Next Previous
            LinkButton lbtJumpPrevious = new LinkButton();
            lbtJumpPrevious.ID = "lbtJumpPrevious";
            lbtJumpPrevious.Text = String.Format((" <img border=\"0\" width=\"16\" height=\"16\" src=\"{0}\" />   "), "../imgs/Systems/previous.png");
            lbtJumpPrevious.ToolTip = "Nhảy về sau " + pagesJumpPrevious + " trang";
            lbtJumpPrevious.Click += new EventHandler(nextPrevious_Click);
            this.pnlPager.Controls.Add(lbtJumpPrevious);

            LinkButton lbtJumpNext = new LinkButton();
            lbtJumpNext.ID = "lbtJumpNext";
            lbtJumpNext.Text = String.Format(("<img border=\"0\" width=\"16\" height=\"16\" src=\"{0}\" />    "), "../imgs/Systems/next.png");
            lbtJumpNext.ToolTip = "Nhảy lên trước " + pagesJumpNext + " trang";
            lbtJumpNext.Click += new EventHandler(nextPrevious_Click);
            this.pnlPager.Controls.Add(lbtJumpNext);
        }

        void CalculateStartEnd()
        {
            if (PESSession.Get(sessionPage) != null)
                currentPage = int.Parse(PESSession.Get(sessionPage).ToString());
            else
            {
                currentPage = 1;
                PESSession.Set(sessionPage, 1);
            }

            if (currentPage == 0)
                currentPage = 1;

            start = currentPage * pageSize - (pageSize - 1);
            end = start + pageSize - 1;
        }

        int CalculateTotalPages()
        {
            int result = 0;
            if (totalItems % pageSize == 0)
                result = totalItems / pageSize;
            else
                result = totalItems / pageSize + 1;
            return result;
        }

        void AddDropDownListJumpTo()
        {
            Label lblSpace = new Label();
            lblSpace.Text = "&nbsp;&nbsp;";
            lblSpace.ID = "lblSpace";
            this.pnlPager.Controls.Add(lblSpace);


            DropDownList ddlJumpTo = new DropDownList();
            ddlJumpTo.ID = "ddlJumpTo";

            for (int i = 1; i <= totalPages; i++)
                ddlJumpTo.Items.Add(new ListItem(i.ToString(), i.ToString()));
            Commons.SelectDropDownList(ddlJumpTo, currentPage.ToString());
            ddlJumpTo.SelectedIndexChanged += new EventHandler(ddlJumpTo_SelectedIndexChanged);
            ddlJumpTo.AutoPostBack = true;
            this.pnlPager.Controls.Add(ddlJumpTo);
        }

        #region Event
        void ddlJumpTo_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ddlJump = sender as DropDownList;
            LinkButton lbt = new LinkButton();
            lbt.ID = ddlJump.SelectedItem.ToString();
            lbt_Click(lbt, new EventArgs());
        }

        void nextPrevious_Click(object sender, EventArgs e)
        {

            LinkButton lbt = sender as LinkButton;
            LinkButton lbtPage = new LinkButton();
            int newPage = currentPage;
            if (lbt.ID == "lbtJumpNext")
            {
                newPage += pagesJumpNext;
                if (newPage > totalPages)
                    newPage = totalPages;
            }
            else if (lbt.ID == "lbtJumpPrevious")
            {
                newPage -= pagesJumpPrevious;
                if (newPage < 1)
                    newPage = 1;
            }

            lbtPage.ID = newPage.ToString();
            lbt_Click(lbtPage, new EventArgs());
        }

        void lbt_Click(object sender, EventArgs e)
        {

            int page = int.Parse(((LinkButton)sender).ID);
            PESSession.Set(sessionPage, page);
            currentPage = page;
            CalculateStartEnd();

            PESSession.Set(sessionPageChanged, true);
        }
        #endregion

        #region Properties
        [Category("PageSize"), Bindable(false)]
        public int PageSize
        {
            set
            {
                this.pageSize = Commons.ConvertToInt(value.ToString(), 2);
            }
            get
            {
                return this.pageSize;
            }
        }


        [Category("Control"), Bindable(false)]
        public int FirstPagesDisplay
        {
            set
            {
                this.firstPagesDisplay = Commons.ConvertToInt(value.ToString(), 5);
            }
            get
            {
                return this.firstPagesDisplay;
            }
        }

        [Category("Control"), Bindable(false)]
        public int LastPagesDisplay
        {
            set
            {
                this.lastPagesDisplay = Commons.ConvertToInt(value.ToString(), 3);
            }
            get
            {
                return this.lastPagesDisplay;
            }
        }

        [Category("Control"), Bindable(false)]
        public int PagesJumpNext
        {
            set
            {
                this.pagesJumpNext = Commons.ConvertToInt(value.ToString(), 5);
            }
            get
            {
                return this.pagesJumpNext;
            }
        }

        [Category("Control"), Bindable(false)]
        public int PagesJumpPrevious
        {
            set
            {
                this.pagesJumpPrevious = Commons.ConvertToInt(value.ToString(), 5);
            }
            get
            {
                return this.pagesJumpPrevious;
            }
        }

      

        [Category("Session"), Bindable(false)]
        public string SessionPageChanged
        {
            set
            {
                this.sessionPageChanged = value.ToString();
            }
            get
            {
                return this.sessionPageChanged;
            }
        }


        [Category("Session"), Bindable(false)]
        public string SessionPage
        {
            set
            {
                this.sessionPage = value.ToString();
            }
            get
            {
                return this.sessionPage;
            }
        }
        #endregion
    }

}