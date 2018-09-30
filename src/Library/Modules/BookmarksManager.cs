using System;
using System.Collections.Generic;

namespace FastColoredTextBoxNS
{
    /// <summary>
    /// Base class for bookmark collection
    /// </summary>
    public abstract class BaseBookmarks : ICollection<Bookmark>, IDisposable
    {
        #region ICollection
        public abstract void Add(Bookmark item);
        public abstract void Clear();
        public abstract bool Contains(Bookmark item);
        public abstract void CopyTo(Bookmark[] array, int arrayIndex);
        public abstract int Count { get; }
        public abstract bool IsReadOnly { get; }
        public abstract bool Remove(Bookmark item);
        public abstract IEnumerator<Bookmark> GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        public abstract void Dispose();

        #region Additional properties
        /// <summary>
        /// Bookmark the current line
        /// </summary>
        public abstract void Add();

        public abstract bool Contains(int lineIndex);

        /// <summary>
        /// Removes the <see cref="Bookmark"/> from the selected line if there is any
        /// </summary>
        /// <returns><c>TRUE</c> if a <see cref="Bookmark"/> removed from the line,
        /// <c>FALSE</c> otherwise</returns>
        public abstract bool Remove();

        public abstract Bookmark GetBookmark(int i);
        #endregion
    }

    /// <summary>
    /// Collection of bookmarks
    /// </summary>
    public class BookmarksManager : BaseBookmarks
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

        public override void Dispose()
        {
            tb.LineInserted -= tb_LineInserted;
            tb.LineRemoved -= tb_LineRemoved;
        }

        public override IEnumerator<Bookmark> GetEnumerator()
        {
            foreach (var item in items)
                yield return item;
        }

        private void Add(int lineIndex, string bookmarkName)
        {
            Add(new Bookmark(tb, bookmarkName, lineIndex));
        }

        private void Add(int lineIndex)
        {
            Add(new Bookmark(tb, "Bookmark " + counter, lineIndex));
        }

        public override void Add()
        {
            Add(tb.Selection.Start.iLine);
        }

        public override void Clear()
        {
            items.Clear();
            counter = 0;
        }

        public override void Add(Bookmark bookmark)
        {
            if (Contains(bookmark.LineIndex))
                    return;

            items.Add(bookmark);
            counter++;
            tb.Invalidate();
        }

        public override bool Contains(Bookmark item)
        {
            return items.Contains(item);
        }

        public override bool Contains(int lineIndex)
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

        public override void CopyTo(Bookmark[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override bool Remove(Bookmark item)
        {
            tb.Invalidate();
            return items.Remove(item);
        }

        /// <summary>
        /// Removes bookmark by line index
        /// </summary>
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

        public override bool Remove()
        {
            return Remove(tb.Selection.Start.iLine);
        }

        /// <summary>
        /// Returns Bookmark by index.
        /// </summary>
        public override Bookmark GetBookmark(int i)
        {
            return items[i];
        }
    }
}
