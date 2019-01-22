using FastColoredTextBoxNS.Modules;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FastColoredTextBoxNS
{
    public interface IBookmarksManager : ICollection<Bookmark>
    {
        new IEnumerator<Bookmark> GetEnumerator();

        /// <summary>
        /// Bookmark the current line if not bookmarked yet
        /// </summary>
        void Add();

        bool Contains(int lineIndex);

        /// <summary>
        /// Removes the <see cref="Bookmark"/> from the selected line if there is any
        /// </summary>
        /// <returns><c>TRUE</c> if a <see cref="Bookmark"/> removed from the line,
        /// <c>FALSE</c> otherwise</returns>
        bool Remove();
    }

    /// <summary>
    /// Collection of bookmarks
    /// </summary>
    public class BookmarksManager : IBookmarksManager, IModule
    {
        protected List<Bookmark> items = new List<Bookmark>();
        protected int counter;

        private Dictionary<int, Bookmark> _bookmarksByLineIndex = new Dictionary<int, Bookmark>();
        private FastColoredTextBox _textBox;



        public BookmarksManager()
        {
            _textBox = new FastColoredTextBox();
        }



        public void Assing(FastColoredTextBox textBox)
        {
            _textBox = textBox;
        }

        public IEnumerator<Bookmark> GetEnumerator()
        {
            foreach (var item in items)
                yield return item;
        }

        public void Add()
        {
            Add(_textBox.Selection.Start.iLine, "Bookmark " + counter);
        }

        public void Clear()
        {
            items.Clear();
            counter = 0;
            _bookmarksByLineIndex.Clear();
        }

        public void Add(Bookmark bookmark)
        {
            if (Contains(bookmark.LineIndex))
                    return;

            items.Add(bookmark);
            _bookmarksByLineIndex[bookmark.LineIndex] = bookmark;
            counter++;
            _textBox.Invalidate();
        }

        public bool Contains(Bookmark item)
        {
            return items.Contains(item);
        }

        public bool Contains(int lineIndex)
        {
            foreach (var item in items)
            {
                if (item.LineIndex == lineIndex)
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(Bookmark[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Bookmark item)
        {
            _textBox.Invalidate();
            _bookmarksByLineIndex.Remove(item.LineIndex);
            return items.Remove(item);
        }

        private bool Remove(int lineIndex)
        {
            bool was = false;
            for (int i = 0; i < Count; i++)
            if (items[i].LineIndex == lineIndex)
            {
                items.RemoveAt(i);
                    _bookmarksByLineIndex.Remove(lineIndex);
                i--;
                was = true;
            }
            _textBox.Invalidate();

            return was;
        }

        public bool Remove()
        {
            return Remove(_textBox.Selection.Start.iLine);
        }

        /// <summary>
        /// Scrolls to nearest previous bookmark or to last bookmark
        /// </summary>
        public bool GotoPrevBookmark()
        {
            Bookmark nearestBookmark = null;
            int maxPrevLineIndex = -1;
            Bookmark maxBookmark = null;
            int maxLineIndex = -1;
            foreach (Bookmark bookmark in items)
            {
                if (bookmark.LineIndex > maxLineIndex)
                {
                    maxLineIndex = bookmark.LineIndex;
                    maxBookmark = bookmark;
                }

                if (bookmark.LineIndex < _textBox.Selection.Start.iLine && bookmark.LineIndex > maxPrevLineIndex)
                {
                    maxPrevLineIndex = bookmark.LineIndex;
                    nearestBookmark = bookmark;
                }
            }

            if (nearestBookmark != null)
            {
                nearestBookmark.DoVisible();
                return true;
            }
            else if (maxBookmark != null)
            {
                maxBookmark.DoVisible();
                return true;
            }

            return false;
        }



        /// <summary>
        /// Scrolls to nearest bookmark or to first bookmark
        /// </summary>
        public bool GotoNextBookmark()
        {
            Bookmark nearestBookmark = null;
            int minNextLineIndex = int.MaxValue;
            Bookmark minBookmark = null;
            int minLineIndex = int.MaxValue;
            foreach (Bookmark bookmark in items)
            {
                if (bookmark.LineIndex < minLineIndex)
                {
                    minLineIndex = bookmark.LineIndex;
                    minBookmark = bookmark;
                }

                if (bookmark.LineIndex > _textBox.Selection.Start.iLine && bookmark.LineIndex < minNextLineIndex)
                {
                    minNextLineIndex = bookmark.LineIndex;
                    nearestBookmark = bookmark;
                }
            }

            if (nearestBookmark != null)
            {
                nearestBookmark.DoVisible();
                return true;
            }
            else if (minBookmark != null)
            {
                minBookmark.DoVisible();
                return true;
            }

            return false;
        }

        public void OnPaint(int lineIndex, PaintEventArgs e, LineInfo lineInfo)
        {
            if (_bookmarksByLineIndex.ContainsKey(lineIndex))
            {
                int y = lineInfo.startY - _textBox.VerticalScroll.Value;

                _bookmarksByLineIndex[lineIndex].Paint(
                    e.Graphics,
                    new Rectangle(_textBox.LeftIndent, y, _textBox.Width, _textBox.CharHeight * lineInfo.WordWrapStringsCount));
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        private void Add(int lineIndex, string bookmarkName)
        {
            Add(new Bookmark(_textBox, bookmarkName, lineIndex));
        }

        public void LineInserted(int index, int count)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].LineIndex >= index)
                {
                    items[i].LineIndex = items[i].LineIndex + count;
                }
                else
                if (items[i].LineIndex == index - 1 && count == 1)
                {
                    if (_textBox[index - 1].StartSpacesCount == _textBox[index - 1].Count)
                        items[i].LineIndex = items[i].LineIndex + count;
                }
            } 
        }

        public void LineRemoved(int index, int count, List<int> removedLineIds)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].LineIndex >= index)
                {
                    if (items[i].LineIndex >= index + count)
                    {
                        items[i].LineIndex = items[i].LineIndex - count;
                        continue;
                    }

                    var was = index <= 0;
                    foreach (var b in items)
                        if (b.LineIndex == index - 1)
                            was = true;

                    if (was)
                    {
                        items.RemoveAt(i);
                        i--;
                    }
                    else
                        items[i].LineIndex = index - 1;
                }
            }
        }
    }
}
