using System;
using System.Collections;
using System.Collections.Generic;

namespace FastColoredTextBoxNS
{
    public interface IBookmarksManager : ICollection<Bookmark>, IDisposable
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
    public class BookmarksManager : IBookmarksManager
    {
        protected FastColoredTextBox tb;
        protected List<Bookmark> items = new List<Bookmark>();
        protected int counter;



        public BookmarksManager(FastColoredTextBox tb)
        {
            this.tb = tb;
            tb.LineInserted += tb_LineInserted;
            tb.LineRemoved += tb_LineRemoved;
        }



        protected virtual void tb_LineRemoved(object sender, LineRemovedEventArgs e)
        {
            for(int i=0; i<Count; i++)
            if (items[i].LineIndex >= e.Index)
            {
                if (items[i].LineIndex >= e.Index + e.Count)
                {
                    items[i].LineIndex = items[i].LineIndex - e.Count;
                    continue;
                }

                var was = e.Index <= 0;
                foreach (var b in items)
                    if (b.LineIndex == e.Index - 1)
                        was = true;

                if(was)
                {
                    items.RemoveAt(i);
                    i--;
                }else
                    items[i].LineIndex = e.Index - 1;
            }
        }

        protected virtual void tb_LineInserted(object sender, LineInsertedEventArgs e)
        {
            for (int i = 0; i < Count; i++)
                if (items[i].LineIndex >= e.Index)
                {
                    items[i].LineIndex = items[i].LineIndex + e.Count;
                }else
                if (items[i].LineIndex == e.Index - 1 && e.Count == 1)
                {
                    if(tb[e.Index - 1].StartSpacesCount == tb[e.Index - 1].Count)
                        items[i].LineIndex = items[i].LineIndex + e.Count;
                }
        }

        public IEnumerator<Bookmark> GetEnumerator()
        {
            foreach (var item in items)
                yield return item;
        }

        private void Add(int lineIndex, string bookmarkName)
        {
            Add(new Bookmark(tb, bookmarkName, lineIndex));
        }

        public void Add()
        {
            Add(tb.Selection.Start.iLine, "Bookmark " + counter);
        }

        public void Clear()
        {
            items.Clear();
            counter = 0;
        }

        public void Add(Bookmark bookmark)
        {
            if (Contains(bookmark.LineIndex))
                    return;

            items.Add(bookmark);
            counter++;
            tb.Invalidate();
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
            tb.Invalidate();
            return items.Remove(item);
        }

        private bool Remove(int lineIndex)
        {
            bool was = false;
            for (int i = 0; i < Count; i++)
            if (items[i].LineIndex == lineIndex)
            {
                items.RemoveAt(i);
                i--;
                was = true;
            }
            tb.Invalidate();

            return was;
        }

        public bool Remove()
        {
            return Remove(tb.Selection.Start.iLine);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            tb.LineInserted -= tb_LineInserted;
            tb.LineRemoved -= tb_LineRemoved;
        }
    }
}
