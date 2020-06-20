using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml;

namespace ADT
{
    public class MyLinkedList<T> : ILab2List<T>
    {
        public class Node
        {
            public Node(T data)
            {
                Data = data;
                NextNode = null;
            }

            /*Element that will be stored in the list*/
            public T Data { get; set; }
            /*Reference to the next node in the list*/
            internal Node NextNode { get; set; }
        }

        /*Declare field -> pointer to the first element in list 
         also declare a counter*/
        private Node top;
        private int count;

        /*Constructor declares empty list*/
        public MyLinkedList()
        {
            top = null;
            count = 0;
        }

        /*Indexer checks validity of the specified index and then starts from the top of the list goes 
        to the next node index times. Once the node containing the element the specified index is found, 
        it is accessed directly.*/
        public T this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new IndexOutOfRangeException("Invalid index: " + index);
                }
                Node currentNode = top;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }
                return currentNode.Data;

            }
            set
            {
                if (index >= count || index < 0)
                {
                    throw new IndexOutOfRangeException("Invalid index: " + index);
                }
                Node currentNode = top;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }
                currentNode.Data = value;
            }
        }

        /*Add value at the start of the list*/
        public void AddFirst(T data)
        {
            /*Top points to the first node. */
            Node node = new Node(data);
            node.NextNode = top; /*Point to the same node that top is pointing to*/
            top = node; /*Top pointing to the new node*/
            count++; /*Increment*/
        }

        /*Add value at the end of the list*/
        public void AddLast(T data)
        {
            //Creating a new node to add to the End
            Node node = new Node(data);
            /*If empty, point to new node to avoid nullexception*/
            if (top == null)
            {
                //Assign the node to be the first and last
                top = node;
                count++;
                return;
            }
            //Since it will be the last node, assign this next node as null
            node.NextNode = null;

            //Finding the lastNode. Start from the top
            Node lastNode = top;
            //While looping, check the element who has the nextNode = null
            //Since that would be the last node
            while (lastNode.NextNode != null)
                lastNode = lastNode.NextNode;
            //Assigning the reference to the node to be added at the end
            lastNode.NextNode = node;
            count++;
        }

        //Add value at index
        public void AddAt(int index, T data)
        {
            //Getting the top node and get stored it in a tmp
            Node tmp = top;
            Node holder;
            //looping through the elements to find the adjacent element
            for (int i = 0; i < index - 1 && tmp.NextNode != null; i++)
            {
                //Finding the element and the NextNode address to change later
                tmp = tmp.NextNode;
            }
            //Assinging it to the holder
            holder = tmp.NextNode;
            //assinging the NextNode to "Data"
            tmp.NextNode = new Node(data);
            //Changing the address
            tmp.NextNode.NextNode = holder;
            count++;
        }

        //Return count of elements in list
        public int Count()
        {
            return count;
        }
        /*Returns the value we set. If target not in list return -1*/
        public int IndexOf(T target)
        {
            int index = 0;
            Node currentNode = top;

            while (currentNode != null)
            {
                if (Equals(currentNode.Data, target))
                {
                    return index;
                }
                currentNode = currentNode.NextNode;
                index++;
            }
            return -1;
        }

        /*Pushing list elements one step towards the end of the list.
         Then insert the value of the data at location matching with index*/
        public void Insert(int index, T data)
        {
            var head = top;
            //Checking the validity of Index
            if (index < 1)
                Console.WriteLine("Invalid Position");

            /*If node to be added is at the first index
             * then change the top node
             */
            if (index == 1)
            {
                var newNode = new Node(data);
                newNode.NextNode = top;
                head = top;
            }
            else
            {
                /*Locating that particular index*/
                while (index-- != 0)
                {
                    //Whenever the index will be found
                    if (index == 1)
                    {
                        //Create a new node with the value to be inserted
                        var nodeToBeInserted = new Node(data);
                        //exchanging the positions to previous and next element
                        nodeToBeInserted.NextNode = head.NextNode;
                        head.NextNode = nodeToBeInserted;
                        break;
                    }
                    //Keep changing the top unless the index in which the node is to be entered is one
                    top = top.NextNode;
                }
                //And If index is not found
                if (index != 1)
                    Console.WriteLine("Index out of Range");
            }
        }

        /*Target is the element that is to be removed.
         Remove the element that matches with target. If not in list return false
         else return true*/
        public bool Remove(T target)
        {
            //If there is not element
            if (top == null)
                throw new ArgumentNullException("Cannot delete");

            //If the head is the target
            if (top.Data.Equals(target))
            {
                //Make the previous element the top
                top = top.NextNode;
                //Decrease the count
                count--;
                return true;
            }
            //If the element is somewhere at middle
            else
            {
                Node currentNode = top;
                Node previousNode = null;

                //traverse through the head
                while (currentNode != null && !currentNode.Data.Equals(target))
                {
                    //Going one step back from head by assinging the addresses to temp variables
                    previousNode = currentNode;
                    currentNode = currentNode.NextNode;
                }
                //If not found
                if (currentNode == null)
                    throw new ArgumentException("Cannot delete");
                //Exchanging the addresses to delete the one wanted
                previousNode.NextNode = currentNode.NextNode;
                count--;
                return true; 
            }
        }

        /*Remove element at index then push following elements after removed element one step to
         the beginning of the list. If index out of range, throw exception*/
        public bool Remove(int index)
        {
            int countforRemoval = 0;
            //Getting the nodes 
            Node currentNode = top;
            Node previousNode = currentNode;
            //Traversing through the indexes
            while (countforRemoval <= index)
            {
                //Whenever found
                if(countforRemoval == index)
                {
                    //Exchange the addresses
                    previousNode.NextNode = currentNode.NextNode;
                    currentNode = null;
                    count--;
                }
                else
                {
                    //Else keep traversing back
                    previousNode = currentNode;
                    currentNode = currentNode.NextNode;
                }
                //Increment the index
                countforRemoval++;
            }
            return true;
        }

        /*
         * This method will determine the length of the Array to be created
         */
        public int DetermineLength(Node head)
        {
            //Getting the top node
            Node curr = head;
            //Setting the count variable
            int count = 0;
            //Checking if the nodes are null
            while (curr != null)
            {
                //Increment the count
                count++;
                //Change the top node
                curr = curr.NextNode;
            }
            //return the number of elements
            return count;
        }


        /*Copy the lists elements to an array and return it*/
        public T[] ToArray()
        {
            //Determining the length of the Array
            int lengthOfArray = DetermineLength(top);
            //Create Array
            T[] LinkedListArray = new T[lengthOfArray];
            //Set the index to 0
            int index = 0;
            //Get the top Node
            Node currentNode = top;
            //If the node is not at the end
            while (currentNode != null)
            {
                //Adding data in the Array
                LinkedListArray[index++] = currentNode.Data;
                //Changing the top node
                currentNode = currentNode.NextNode;
            }
            //Return the Array
            return LinkedListArray;
        }

        public override string ToString()
        {
            string st = string.Empty;
            Node n = top.NextNode;
            while (n != null)
            {
                st += n.Data.ToString() + "\n";
                n = n.NextNode;
            }
            return st;
        }
    }
}
