using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02
{
    public class LinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head { get; private set; }

        public LinkedListNode<T> Tail { get; private set; }

        // creates a Node from a passed in value calls the another method to add the node to the list
        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        // A Node is passed in, the head is saved as a temp Node, the passed in node is set as the Head
        // and the new head is set to point to the Temp Node one is added to the Count of the list
        public void AddFirst(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = Head;

            Head = node;
            Head.Next = temp;

            Count++;

            if (Count == 1)
            {
                Tail = Head;
            }
        }

        // creates a Node from a passed in value calls the another method to add the node to the list
        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }
        // A Node is passed in, If the Count is Zero it becomes the head otherwise the new node is set to be
        // the next node after the Tail and then the tail is set to be that next node, one is added to the Count
        public void AddLast(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }

            Tail = node;
            Count++;
        }
        // if there are elements in the list the head is moved to the next node and the count decreased
        // if the count is now zero the Tails next element now points to null making the list empty
        public void RemoveFirst()
        {
            if (Count != 0)
            {
                Head = Head.Next;
                Count--;
                if (Count == 0)
                {
                    Tail = null;
                }
            }
            
        }
        // if the list is not empty and the Count is 1 the Head and the Tail become null
        // else the count is not 1 we enumerate through the list until we reach the element before the Tail
        //  we stop that element pointing to the tail and make it the new tail
        public void RemoveLast()
        {
            if (Count != 0)
            {
                if(Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    LinkedListNode<T> current = Head;
                    while (current.Next != Tail)
                    {
                        current = current.Next;
                    }
                    current.Next = null;
                    Tail = current;
                }

                Count--;
            }
        }

        // keeps track of the amount of elements in the list
        public int Count { get; set; }

        // a simple way to call the AddFirst method
        public void Add (T item)
        {
            AddFirst(item);
        }

        // when called Contains() checks through each element of the list and checks against the passed in value for equality
        // if an equal value is found it returns true else it returns false
        public bool Contains(T item)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        // loops through each element in the Linked List and copies the value to the appropriate index of the passed in array 
        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        // enumerates through the list looking for a match to the passed in item 
        // if one is found the previous node is set to point to the next node and visa versa and returns true
        // else returns false
        public bool Remove (T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if(current.Next == null)
                        {
                            Tail = previous;
                        }
                        Count--;
                    }
                    else
                    {
                        RemoveFirst();
                    }
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        // allows us to enumerate through the Linked List using loops
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        //^^
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
        // sets the Head and Tail to be null and the count to be 0 clearing the list of all nodes
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        
    }
}
