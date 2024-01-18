using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment02
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        public DoublyLinkedListNode<T> Head
        {
            get;
            private set;
        }

        public DoublyLinkedListNode<T> Tail
        {
            get;
            private set;
        }

        // creates a Node from a passed in value calls the another method to add the node to the list
        public void AddFirst(T value)
        {
            AddFirst(new DoublyLinkedListNode<T>(value));
        }

        // A Node is passed in, the head is saved as a temp Node, the passed in node is set as the Head
        // and the new head is set to point to the Temp Node  and the temp nodes previous is set to point to the Head
        // one is added to the Count of the list
        public void AddFirst(DoublyLinkedListNode<T> node)
        {
            // saving the head
            DoublyLinkedListNode<T> temp = Head;

            // point to new node
            Head = node;

            // placing the rest of th list after the node
            Head.Next = temp;

            if (Count == 0)
            {
                Tail = Head;
            }
            else
            {
                // setting the head as the previous for the temp(2nd node)
                temp.Previous = Head;
            }
            Count++;
        }

        // creates a Node from a passed in value calls the another method to add the node to the list
        public void AddLast(T value)
        {
            AddLast(new DoublyLinkedListNode<T>(value));
        }
        // A Node is passed in, If the Count is Zero it becomes the head otherwise the new node is set to be
        // the next node after the Tail the previous of the new node is set to the tail and then the tail is set to be that next node, one is added to the Count
        public void AddLast(DoublyLinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {

                Tail.Next = node;

                node.Previous = Tail;
            }

            Tail = node;
            Count++;
        }
        // if there are elements in the list the head is moved to the next node and the count decreased
        // if the count is now zero the Tails next element now points to null making the list empty else the
        // new Heads previous is set to null
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
                else
                {
                    Head.Previous = null;
                }
            }
        }

        // if the list is not empty and the Count is 1 the Head and the Tail become null
        // else the count is not 1 we stop the previous node from pointing to the Tail and
        // set the tail to be the previous node
        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Tail.Previous.Next = null;
                    Tail = Tail.Previous;
                }
                Count--;
            }
        }

        // keeps track of the amount of nodes in the list
        public int Count
        {
            get;
            private set;
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        // a simple way to call the add first method
        public void Add(T item)
        {
            AddFirst(item);
        }

        // sets the Head and Tail to be null and the count to be 0 clearing the list of all nodes
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        // when called Contains() checks through each element of the list and checks against the passed in value for equality
        // if an equal value is found it returns true else it returns false
        public bool Contains(T item)
        {
            DoublyLinkedListNode<T> current = Head;
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
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        // enumerates through the list looking for a match to the passed in item 
        // if one is found the previous node is set to point to the next node and visa versa, then returns true
        // else returns false
        public bool Remove(T item)
        {
            DoublyLinkedListNode<T> previous = null;
            DoublyLinkedListNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    //its a node in the middle or end
                    if(previous != null)
                    {
                        previous.Next = current.Next;

                        //it was the end so update Tail
                        if (current.Next == null)
                        {
                            Tail = previous;
                        }
                        else
                        {
                            current.Next.Previous = previous;
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
        // allows us to loop through an array 
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        // ^^
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
