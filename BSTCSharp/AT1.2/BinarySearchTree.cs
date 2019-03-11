using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT1._2
{
    class BinarySearchTree<T>
    {
        public TreeNode<T> Root { get; set; }

        public BinarySearchTree() { this.Root = null; }

        public void Insert(T x) { this.Root = Insert(x, this.Root); }

        public void Remove(T x) { this.Root = Remove(x, this.Root); }

        public void RemoveMin() { this.Root = RemoveMin(this.Root); }

        public T FindMin() { return ElementAt(FindMin(this.Root)); }

        public T FindMax() { return ElementAt(FindMax(this.Root)); }

        public T Find(T x) { return ElementAt(Find(x, this.Root)); }

        public void MakeEmpty() { this.Root = null; }

        public bool IsEmpty() { return this.Root == null; }

        private T ElementAt(TreeNode<T> t) { return t == null ? default(T) : t.Element; }

        private TreeNode<T> Find(T x, TreeNode<T> t) { while (t != null) { if ((x as IComparable).CompareTo(t.Element) < 0) t = t.Left; else if ((x as IComparable).CompareTo(t.Element) > 0) t = t.Right; else return t; } return null; }

        private TreeNode<T> FindMin(TreeNode<T> t) { if (t != null) { while (t.Left != null) { t = t.Left; } } return t; }

        private TreeNode<T> FindMax(TreeNode<T> t)
        {
            if (t != null) { while (t.Right != null) { t = t.Right; } }
            return t;
        }

        protected TreeNode<T> Insert(T x, TreeNode<T> t) { if (t == null) t = new TreeNode<T>(x); else if ((x as IComparable).CompareTo(t.Element) < 0) t.Left = Insert(x, t.Left); else if ((x as IComparable).CompareTo(t.Element) > 0) t.Right = Insert(x, t.Right); else throw new Exception("Duplicate item"); return t; }
        protected TreeNode<T> RemoveMin(TreeNode<T> t) { if (t == null) throw new Exception("Item not found"); else if (t.Left != null) { t.Left = RemoveMin(t.Left); return t; } else return t.Right; }

        protected TreeNode<T> Remove(T x, TreeNode<T> t) { if (t == null) throw new Exception("Item not found"); else if ((x as IComparable).CompareTo(t.Element) < 0) t.Left = Remove(x, t.Left); else if ((x as IComparable).CompareTo(t.Element) > 0) t.Right = Remove(x, t.Right); else if (t.Left != null && t.Right != null) { t.Element = FindMin(t.Right).Element; t.Right = RemoveMin(t.Right); } else t = (t.Left != null) ? t.Left : t.Right; return t; }

        public override string ToString() { return this.Root.ToString(); }
    }
}
