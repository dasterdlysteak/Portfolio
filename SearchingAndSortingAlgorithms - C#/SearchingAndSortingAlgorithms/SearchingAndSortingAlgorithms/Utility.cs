using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02
{
    public class Utility
    {

        // loops through the list comparing the current value to the next value if the current value
        // is greater that the next value according to that items CompareTo method the values inside the nodes are swapped 
        // and the current node switches to the next node
        public void DoubleBubbleSortASC<T>(DoublyLinkedList<T> list) where T : IComparable<T>
        {
            try {
                int count = list.Count;
                for (int j = 0; j < count - 1; j++)
                {
                    DoublyLinkedListNode<T> current = list.Head;
                    for (int i = 0; i < count - 1 - j; i++)
                    {
                        DoublyLinkedListNode<T> nextNode = current.Next;

                        if (current.Value.CompareTo(current.Next.Value) > 0)
                        {
                            T temp = current.Value;
                            current.Value = nextNode.Value;
                            nextNode.Value = temp;
                        }

                        current = current.Next;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There has been an error in the DoubleBubbleSortASC Method: {ex}");
            }
            
        }
        // loops through the list comparing the current value to the next value if the current value
        // is less than the next value according to that items CompareTo method the values inside the nodes are swapped 
        // and the current node switches to the next node
        public void DoubleBubbleSortDESC<T>(DoublyLinkedList<T> list) where T : IComparable<T>
        {
            try
            {
                int count = list.Count;
                for (int j = 0; j < count - 1; j++)
                {
                    DoublyLinkedListNode<T> current = list.Head;
                    for (int i = 0; i < count - 1 - j; i++)
                    {
                        DoublyLinkedListNode<T> nextNode = current.Next;

                        if (current.Value.CompareTo(current.Next.Value) < 0)
                        {
                            T temp = current.Value;
                            current.Value = nextNode.Value;
                            nextNode.Value = temp;
                        }

                        current = current.Next;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There has been an error in the DoubleBubbleSortDESC Method: {ex}");
            }
        }

        // loops through the list comparing the current value to the next value if the current value
        // is greater that the next value according to that items CompareTo method the values inside the nodes are swapped 
        // and the current node switches to the next node
        public void SingleBubbleSortASC<T>(LinkedList<T> list) where T : IComparable<T>
        {
            try
            {
                int count = list.Count;
                for (int j = 0; j < count - 1; j++)
                {
                    LinkedListNode<T> current = list.Head;

                    for (int i = 0; i < count - 1 - j; i++)
                    {
                        LinkedListNode<T> nextNode = current.Next;

                        if (current.Value.CompareTo(current.Next.Value) > 0)
                        {
                            T temp = current.Value;
                            current.Value = nextNode.Value;
                            nextNode.Value = temp;
                        }

                        current = current.Next;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There has been an error in the SingleBubbleSortASC Method: {ex}");
            }
        }
        // loops through the list comparing the current value to the next value if the current value
        // is less than that the next value according to that items CompareTo method the values inside the nodes are swapped 
        // and the current node switches to the next node
        public void SingleBubbleSortDESC<T>(LinkedList<T> list) where T : IComparable<T>
        {
            try
            {
                int count = list.Count;
                for (int j = 0; j < count - 1; j++)
                {
                    LinkedListNode<T> current = list.Head;

                    for (int i = 0; i < count - 1 - j; i++)
                    {
                        LinkedListNode<T> nextNode = current.Next;

                        if (current.Value.CompareTo(current.Next.Value) < 0)
                        {
                            T temp = current.Value;
                            current.Value = nextNode.Value;
                            nextNode.Value = temp;
                        }
                        current = current.Next;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There has been an error in the SingleBubbleSortDESC Method: {ex}");
            }
        }

        // sets the head and the tail as left and right elements them 
        // while the list has not been fully checked calls the get
        // middle method to set the middle point, checks the middle 
        // against the searched for value if equal returns that value
        // else checks if the middle is higher or lower that the passed in value
        // if higher the right moves to the previous node of the middle and the loop continues until either a match is made or the loop ends
        // if lower the left moves to the Next node of the middle and the loop continues until either a match is made or the loop ends
        // either returns a node or returns null
        public DoublyLinkedListNode<T> DoubleBinarySearch<T>(DoublyLinkedList<T> list, T value) where T : IComparable<T>
        {
            try
            {
                DoublyLinkedListNode<T> left = list.Head;
                DoublyLinkedListNode<T> right = list.Tail;
                while (left != null && right != null && right.Next != left)// last condition only needed if working with a circular linked list
                {
                    DoublyLinkedListNode<T> middle = GetMiddle(left, right);
                    if (middle.Value.CompareTo(value) == 0)
                    {
                        return middle;
                    }

                    else if (middle.Value.CompareTo(value) < 0)
                    {
                        left = middle.Next;
                    }
                    else
                    {
                        right = middle.Previous;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There has been an error in the DoubleBinarySearch Method: {ex}");
                return null;
            }
        }
        // Converts the passed in LinkedList into an array sets the left to be index 0 and the right to be the last index
        // while the list hasnt been completely checked the middle is calculated by adding the left and right together
        // then dividing by 2, checks the middle for equality with the passed in value, if equal return the object
        // else if the middle is greater than the object the right is set to the index minus 1
        // else if the middle is lower than the object the left is set to the index plus one
        // repeat untill the object is found of the list is exausted and null is returned

        public T SingleBinarySearch<T>(LinkedList<T> list, T value) where T : IComparable<T>
        {
            try
            {
                T[] array = new T[list.Count];
                list.CopyTo(array, 0);
                int left = 0;
                int right = array.Length - 1;
                
                while (left <= right)
                {
                    int mid = (left + right) / 2;
                    if (array[mid].CompareTo(value) == 0)
                    {
                        return array[mid];
                    }
                    else if (array[mid].CompareTo(value) < 0)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;

                    }
                }

                return default(T);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"There has been an error in the SingleBinarySearch Method: {ex}");
                return default(T);
            }
        }

        // enumerates through the list if the object is found return that node else return false
        public DoublyLinkedListNode<T> DoubleSequentialSearch<T>(DoublyLinkedList<T> list, T value) where T : IComparable<T>
        {
            try
            {
                DoublyLinkedListNode<T> current = list.Head;
                
                for (int i = 0; i < list.Count; i++)
                {
                    if (current.Value.CompareTo(value) == 0)
                    {
                        return current;
                    }
                    current = current.Next;
                } 
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There has been an error in the DoubleSequentialSearch Method: {ex}");
                return null;
            }
        }

        // enumerates through the list if the object is found return that node else return false
        public LinkedListNode<T> SingleSequentialSearch<T>(LinkedList<T> list, T value) where T : IComparable<T>
        {
            try
            {
                LinkedListNode<T> current = list.Head;
                for (int i = 0; i < list.Count; i++)
                {
                    if (current.Value.CompareTo(value) == 0)
                    {
                        return current;
                    }
                    current = current.Next;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There has been an error in the SingleSequentialSearch Method: {ex}");
                return null;
            }
        }

        // a method for finding the middle point of a linked list two variables enumerate through the list, 
        // the fast variable by two places at a time and the slow by one place at a time - when the faster
        // variable reaches the end of the list the slower variable is in the middle - return the slow node
        public DoublyLinkedListNode<T> GetMiddle<T>(DoublyLinkedListNode<T> left, DoublyLinkedListNode<T> right)
        {
            try
            {
                DoublyLinkedListNode<T> slow = left;
                DoublyLinkedListNode<T> Fast = left;
                while (Fast != right && Fast.Next != right)
                {
                    slow = slow.Next;
                    Fast = Fast.Next.Next;
                }
                return slow;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"There has been an error in the GetMiddle Method: {ex}");
                return null;
            }
        }

        // Linear search for an array of type list  List
        // loops through each element in the list checking for equality if found the object is return else null is returned
        public T ListLinearSearch<T>(List<T> list, T value)
        {
            try
            {
                
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (list[i].Equals(value))
                    {
                        return list[i];
                    }   
                }
                return default(T);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There has been an error in the ListLinearSearch Method: {ex}");
                return default(T);
            }
        }
        // sets the left to be index 0 and the right to be the last index
        // while the list hasnt been completely checked the middle is calculated by adding the left and right together
        // then dividing by 2, checks the middle for equality with the passed in value, if equal return the object
        // else if the middle is greater than the object the right is set to the index minus 1
        // else if the middle is lower than the object the left is set to the index plus one
        // repeat untill the object is found of the list is exausted and null is returned
        public T ListBinarySearch<T>(List<T> list, T value) where T : IComparable<T>
        {
            try
            {
                int left = 0;
                int right = list.Count - 1;

                while (left <= right)
                {
                    int mid = (left + right) / 2;
                    if (list[mid].CompareTo(value) == 0)
                    {
                        return list[mid];
                    }
                    else if (list[mid].CompareTo(value) < 0)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;

                    }
                }

                return default(T);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There has been an error in the ListBinarySearch Method: {ex}");
                return default(T);
            }
        }
        // loops through the list comparing the current value to the next value if the current index's value
        // is greater that the next index's value according to that items CompareTo method the value at that index is swapped 
        // and the loop continues on to the next index
        public void ListBubbleSort<T>(List<T> list) where T : IComparable<T>
        {
            int count = list.Count - 1;

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count - i; j++)
                {
                    if (list[j].CompareTo(list[j + 1]) > 0)
                    {
                        T temp = list[j];
                        list[j] = list[j + 1];
                        list[j +1] = temp;
                    }
                }
            }
        }
    }
}
