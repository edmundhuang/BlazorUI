using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUI.Client.CoreUI
{
    public class RouterLink
    {
        private RouterLinkList _children;

        public RouterLink ParentLink { get; set; }
        public string Title { get; set; }
        public string Uri { get; set; }

        public RouterLinkList Children
        {
            get
            {
                if (_children == null)
                    _children = new RouterLinkList();

                return _children;
            }
        }

        public void AddChild(RouterLink child)
        {
            if (child == null)
                return;

            _children.Add(this,child);
        }
    }

    public class RouterLinkList : IEnumerable<RouterLink>
    {
        private List<RouterLink> _list;

        public IEnumerator<RouterLink> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public void Add(RouterLink parent, RouterLink child)
        {
            child.ParentLink = parent;

            if (_list == null)
                _list = new List<RouterLink>();

            _list.Add(child);
        }
    }
}
