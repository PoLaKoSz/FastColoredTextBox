using System;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class BookmarksSample : Form
    {
        private readonly BookmarksManager _bookmarks;



        public BookmarksSample()
        {
            InitializeComponent();

            _bookmarks = new BookmarksManager();
            _bookmarks.Assing(fctb);

            fctb.SubscribedModules.Add(_bookmarks);
        }



        private void btAddBookmark_Click(object sender, EventArgs e)
        {
            _bookmarks.Add();
        }

        private void btRemoveBookmark_Click(object sender, EventArgs e)
        {
            _bookmarks.Remove();
        }

        private void btGo_DropDownOpening(object sender, EventArgs e)
        {
            btGo.DropDownItems.Clear();

            foreach (var bookmark in _bookmarks)
            {
                var item = btGo.DropDownItems.Add(bookmark.Name);
                item.Tag = bookmark;
                item.Click += (o, a) => ((Bookmark)(o as ToolStripItem).Tag).DoVisible();
            }
        }

        private void fctb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.X < fctb.LeftIndent)
            {
                var place = fctb.PointToPlace(e.Location);

                if (_bookmarks.Contains(place.iLine))
                {
                    _bookmarks.Remove();
                }
                else
                {
                    _bookmarks.Add();
                }
            }
        }
    }
}
