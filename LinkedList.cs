using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    class NodeList
    {
        public NodeList()
        {
            Next = null;
        }

        public string Data { get; set; }
        public NodeList Next { get; set; }
    }

    class LinkedList
    {
        private NodeList _top;
        private NodeList _last;
        private int _count;
        private NodeList _currentItem;

        public int Insert(string data)
        {
            var node = new NodeList { Data = data };
            if (_top == null)
            {
                _top = node;
                _last = node;
            }
            else
            {
                _last.Next = node;
                _last = node;
            }
            _count++;
            return _count;
        }

        public NodeList GetNodeAt(int position)
        {
            if (position < 0 || position >= _count)
                throw (new IndexOutOfRangeException());
            var current = _top;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public int InsertAt(int position, string data)
        {
            if (position < 0 || position >= _count)
                throw (new IndexOutOfRangeException());
            var node = new NodeList { Data = data };
            if (position == 0)
            {
                node.Next = _top;
                _top = node;
            }
            else
            {
                var current = GetNodeAt(position - 1);
                node.Next = current.Next;
                current.Next = node;
            }
            _count++;
            return _count;
        }

        public void Clear()
        {
            _top = null;
            _count = 0;
        }
        public int Count => _count;
        public int Find(object obj)
        {
            if (Count == 0)
                return -1;
            NodeList current = _top;
            int currentNo = 0;
            do
            {
                if (current.Data.Equals(obj))
                {
                    return currentNo;
                }
                current = current.Next;
                currentNo++;
            } while (current != null);
            return -1;
        }

        public bool Remove(string data)
        {
            var currentItem = Find(data);
            if (currentItem == -1)
                return false;
            if (currentItem == 0)
            {
                _top = _top.Next;
            }
            else
            {
                var previousNode = GetNodeAt(currentItem - 1);
                previousNode.Next = previousNode.Next.Next;
                if (previousNode.Next == null)
                    _last = previousNode;
            }
            _count--;
            return true;
        }

        public bool RemoveAt(int position)
        {
            if (position < 0 || position >= _count)
                throw (new IndexOutOfRangeException());
            if (position == 0)
            {
                _top = _top.Next;
            }
            else
            {
                var previousNode = GetNodeAt(position - 1);
                previousNode.Next = previousNode.Next.Next;
                if (previousNode.Next == null)
                    _last = previousNode;
            }
            _count--;
            return true;
        }
    }
}
