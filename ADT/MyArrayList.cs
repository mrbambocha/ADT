using System;
using System.Linq;

namespace ADT
{
    //MyArraylist implements the ILab2List<T> interface
    public class MyArrayList<T> : ILab2List<T>
    {
        private T[] Nodes { get; set; }

        //Indexr used to access each element by an index like an array.
        public T this[int i]
        {
            get { return Nodes[i]; }
            set { Nodes[i] = value; }
        }


        //Created this count variable to keep the count of the Array
        public int count { get; set; }
        public MyArrayList()
        {
            count = 0;
            Nodes = new T[count];
        }
        //Add element to the beginning of the list
        public void AddFirst(T data)
        {
            //Creating a temporary array with one additional item
            var newNode = new T[count + 1];
            //incrementing the count
            count++;
            //If the array is not empty
            if (Nodes.Length != 0)
            {
                //Loop through the nodes
                for (int i = 0; i < Nodes.Length; i++)
                {
                    //Shift the items to the temporary array except at the 0 index
                    newNode[i + 1] = Nodes[i];
                }
                //Assign the value to 0 index
                newNode[0] = data;
            }
            //If the array is empty
            else if (Nodes.Length == 0)
            {
                //Just assign one element
                newNode[0] = data;
            }
            //assigning it back to the Node
            Nodes = newNode;
        }
        //Add element to end of list
        public void AddLast(T data)
        {
            //Create an array with one size bigger
            var tempArray = new T[count + 1];
            //Looping through the Array
            for (int i = 0; i < Nodes.Length; i++)
            {
                //Assigning the elements to the temporary array
                tempArray[i] = Nodes[i];
            }
            //assinging the value to the last array
            tempArray[tempArray.Length - 1] = data;
            //Assinging back to the Nodes
            Nodes = tempArray;
        }
        //Add value at index
        public void AddAt(int index, T data)
        {
            //Create a temporary Array of one size larger
            var tempArray = new T[Nodes.Length + 1];
            //Check if the index is not less than 0 or greater than length
            if (index < 0 || index > Nodes.Length)
            {
                throw new IndexOutOfRangeException("Index: " + index);
            }
            else
            {
                //Looping through the elements
                for (int i = 0; i < Nodes.Length; i++)
                {
                    //we need to remove the item at INDEX
                    //Therefore shifting the elements to the other indexes whenever the index is encountered
                    if (i >= index)
                        tempArray[i + 1] = Nodes[i];
                    //Else continue the same copying of the elements
                    else
                        tempArray[i] = Nodes[i];
                }
                //Assinging the data to the index
                tempArray[index] = data;
            }
            //Assigning the array back
            Nodes = tempArray;
        }
        //Return all elements in the list
        public int Count()
        {
            return Nodes.Length;
        }
        //Returns index of the appended element. If target not existing, return -1
        public int IndexOf(T target)
        {
            for (int i = 0; i < Nodes.Length; i++)
            {
                //Comparing the node value with the target value
                if (Nodes[i].Equals(target))
                {
                    return i;
                }
            }
            return -1;
        }
        //If item out of range, throw and exception. Otherwise insert values from current index
        //one step to the end of the list then inset value at matching index. 
        public void Insert(int index, T data)
        {
            if (index > Nodes.Length || index < 0)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }
            else
                //Calling the AddAt method with the same index and data
                AddAt(index, data);
        }
        //Removes item that matches with target. If value is missing in the list, return false
        public bool Remove(T target)
        {
            //Getting the index
            int index = IndexOf(target);
            if (index == -1) return false;
            else
                //Calling the remove method
                Remove(index);
            return true;
        }
        //Find the searched element, remove it and then shift the
        //elements after it by one position to the left 
        //in order to fill the empty position

        //Fill the position after the last item in the array with null value(the default(T)) 
        //to allow the garbage collector to release it if it is not needed
        public bool Remove(int index)
        {
            //If the node is greater than length or less than zero, throw the exception
            if (index >= Nodes.Length || index < 0)
            {
                throw new IndexOutOfRangeException(
                "Invalid index: " + index);
            }
            else
            {
                //Create a temporary Array
                var tempArray = new T[Nodes.Length];
                //Assigning the index to be removed a default value
                tempArray[index] = default(T);
                //getting the Length of Nodes
                int lengthOfTheNodes = Nodes.Length;
                //Looping through the length
                for (int i = 0; i < lengthOfTheNodes; i++)
                {
                    //assinging the elements to temporaryArray except the index value
                    if (i != index)
                        tempArray[i] = Nodes[i];
                }
                //Removing all the null values from tempArray using LINQ
                Nodes = tempArray.Where(x => x != null).ToArray();
            }
            return true;
        }
        //Copy the lists elements to an array and return it
        public T[] ToArray()
        {
            //return nodes
            return Nodes;
        }
    }
}
