using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProgPoe1
{
    /// <summary>
    /// Interaction logic for ReplacingBooks.xaml
    /// </summary>
    public partial class ReplacingBooks : Window
    {
        MediaPlayer mp = new MediaPlayer(); 

        char[] randomString;
        char[] randomNumber; 
        string[] names = new string[10];

        DoublyLinkedList<string> list = new DoublyLinkedList<string>(); 


        public ReplacingBooks()
        {
            InitializeComponent();

            SoundPlayer player = new SoundPlayer(new Uri(string.Format("{0}\\Sounds\\pokeball-opening-sound-FX.wav", AppDomain.CurrentDomain.BaseDirectory)).ToString()); 
            player.Play(); 

             
            randomString = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (Char)i).ToArray();
            randomNumber = Enumerable.Range('0', '9' - '0' + 1).Select(i => (Char)i).ToArray();
           
            correctAnswer.Visibility  = Visibility.Hidden; 

            updateListBox(); 
            codeGenerator();

        }

        private void up_Click(object sender, RoutedEventArgs e)
        {
            int currentIndex = sortingList.SelectedIndex;
            if (currentIndex != -1)
            {
                if (currentIndex > 0)//up
                {
                    string holder = sortingList.Items[currentIndex].ToString();
                    sortingList.Items.RemoveAt(currentIndex);
                    sortingList.Items.Insert(currentIndex - 1, holder);
                }
                else
                {
                    MessageBox.Show("out of bounds");
                }
            }

            else
            {
                MessageBox.Show("please select something");
            }
        }

        private void down_Click(object sender, RoutedEventArgs e)
        {
            int currentIndex = sortingList.SelectedIndex;

            if (currentIndex != -1)
            {

                if (currentIndex < 9)//down
                {
                    string holder = sortingList.Items[currentIndex].ToString();
                    sortingList.Items.RemoveAt(currentIndex);
                    sortingList.Items.Insert(currentIndex + 1, holder);


                }
                else
                {
                    MessageBox.Show("out of bounds");
                }
            }
            else
            {
                MessageBox.Show("please select something");
            }
        }

        public void codeGenerator()
        {
            Random rand = new Random();

            //this code generates a random sequence of numbers and letters
            String holder;
            for (int w = 0; w < 10; w++)
            {
                holder = "";

                for (int rString = 0; rString < 3; rString++) 
                {
                   
                    int num = rand.Next(0, 9); 
                    holder = holder + randomNumber[num].ToString();    
                }
                     holder = holder + ".";
                for (int p = 0; p < 2; p++)
                {

                    int num = rand.Next(0, 9);
                    holder = holder + randomNumber[num].ToString();   
                }
                for (int j = 0; j < 3; j++)
                {
                    
                    int rString = rand.Next(0, 25);
                    holder = holder + randomString[rString].ToString();
                }

                // sequence gets saved in an array for comparison
                names[w] = holder;
                // sequence gets displayed in a list thats displayed
                sortingList.Items.Add(holder);

            }
        }


        public void rightAnswer()
        {

            int count = 0;
            // arrays sorts the variables in ascending order
            Array.Sort(names);
            for (int i = 0; i < 10; i++)
            {
                //if the position of a specific variable on the users list is in the same position as the sorted array then the count increases by 1
                if (names[i] == sortingList.Items[i]) 
                {
                    //count variable keeps score
                    count = count + 1;
                }
            }
            if (count < 5)
            {
                // messagebox shows their score
                MessageBox.Show("you got " + count + " out of 10");

                // list view showing the correct answers is displayed
                correctAnswer.Visibility = Visibility.Visible; 
              
                // populates the correct answers list using the sorted array
                foreach (var item in names)
                {

                    correctAnswer.Items.Add(item);  
                }
            }
            else
            {

              
                badge ach =  new badge();
                 
                SoundPlayer player = new SoundPlayer(new Uri(string.Format("{0}\\Sounds\\Pokemon-Victory-Theme.wav", AppDomain.CurrentDomain.BaseDirectory)).ToString());
                player.Play(); 

                 
                MessageBox.Show("You Have Earned");
                ach.Show(); 


            }
        }


        public void updateListBox()
        {

            sortingList.Items.Clear();
            foreach (var item in list) 
            {

                sortingList.Items.Add(item); //adds items to the list  


            }
        }


        //event handler to detect mouse moveent aswell as drag and drop 
        private void ListBoxItem_PreviewMouseMove(object sender, MouseEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //sets up the possibility for drag and drop  
                ListBoxItem draggedItem = sender as ListBoxItem;
                if (draggedItem != null)
                {
                    //allow the drag drop to happen 
                    DragDrop.DoDragDrop(draggedItem, draggedItem.Content, DragDropEffects.Move);

                }
            }

        }



        private void ListBoxItem_Drop(object sender, DragEventArgs e)
        {

            ListBoxItem targetItem = sender as ListBoxItem;
            if (targetItem != null)
            {
                //needs to be a valid item in the list to be moved.   
                // if the items are valid, only then they can be mmoved. 
                int targetIndex = sortingList.Items.IndexOf(targetItem.Content);   

                int draggedIndex = list.IndexOf((string)e.Data.GetData(typeof(string)));

                if (targetIndex >= 0 && draggedIndex >= 0)
                { 
                    list.Move(draggedIndex, targetIndex);
                    updateListBox(); // updates the list of items to the new arranged list. 
                }



            }
            else 
            {

                MessageBox.Show("Error");

            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            rightAnswer(); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide(); 
            MainWindow mw = new MainWindow(); 
            mw.Show(); 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //userAnswer.Items.Clear();
            sortingList.Items.Clear();
            correctAnswer.Items.Clear();
            correctAnswer.Visibility = Visibility.Hidden;
            sortingList.Visibility = Visibility.Visible; 


            codeGenerator();
        }
    } // class ends 


    //public class DoublyLinedLis<T> /* generic class*/: IEnumerable<T> /*Extention for Generic Class*/
    //{
    //    public class node
    //    {

    //        //all these are needed to create 1 doubly linked list
    //        // Head, Data, Tail.  

    //        public T Value { get; set; } //T = any datatype 
    //        public node Next { get; set; } //references 
    //        public node prev { get; set; } // references 

    //    }
    //    public node head;
    //    public node tail;



    //    //Method to add values 

    //    //ADD --> Generic type 
    //    public void Add(T value)
    //    {

    //        node newNode = new node { Value = value };

    //        //if empty-> starts new list 



    //        if (head == null)
    //        {
    //            head = newNode;
    //            tail = newNode;

    //        }
    //        else
    //        {
    //            tail.Next = newNode;
    //            newNode.prev = tail;
    //            tail = newNode;

    //        }

    //    }

    //    //pulls get because it is a requirement. 
    //    // Can not pull th IEnumerator without the GetEnumerator 

    //    //returns ints, strings and objects 
    //    public IEnumerator<T> GetEnumerator()
    //    {
    //        node current = head; //sets the start point 

    //        while (current != null) // if it is not empty, allow for itteration. Yield(force) a return  
    //        {
    //            yield return current.Value;
    //            current = current.Next;
    //        }
    //    }


    //    //non generic 
    //    //provides compatibility for any non generic iterations  
    //    //required so the program does not crash. 
    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return ((IEnumerable<T>)this).GetEnumerator();
    //    }

    //    public int IndexOf(T value)
    //    {
    //        node current = head;
    //        int index = 0;
    //        while (current != null)
    //        {
    //            //it needs to compare the 2 values
    //            // compares the current value to other values 

    //            if (EqualityComparer<T>.Default.Equals(current.Value, value))
    //                return index;
    //            index++;
    //            current = current.Next;
    //        }
    //        //once position --> ie item is sorted 
    //        //take away that slot  as avail

    //        return -1; //indicates the value isnt found. 


    //    }

    //    public void Move(int sourceIndex, int destinationIndex)
    //    {
    //        //check while you move things around in this list? 
    //        if (sourceIndex < 0 || sourceIndex >= count || destinationIndex < 0 || destinationIndex >= count)
    //        {
    //            return;
    //        }
    //        node sourceNode = GetNodeAtIndex(sourceIndex); 
    //        node destNode = GetNodeAtIndex(destinationIndex);

    //        T temp = sourceNode.Value;
    //        sourceNode.Value = destNode.Value;
    //        destNode.Value = temp; //flipping them around 
    //    }

    //    private node GetNodeAtIndex(int index)
    //    {
    //        //right click an generate method 
    //        //remove throw 
    //        node current = head;
    //        for (int i = 0; i < index && current != null; i++)
    //        {
    //            current = current.Next; //will move ontto next node 

    //        }
    //        return current;
    //    }

    //    public int count
    //    {

    //        get
    //        {

    //            int count = 0;
    //            node current = head;
    //            while (current != null)
    //            {
    //                count++;
    //                current = current.Next;
    //            }
    //            return count;

    //        }
    //    }
    // }

    public class DoublyLinkedList<T> : IEnumerable<T>
    {

        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }
        public Node head; // outside of the class as its not needed to be defined multiple times
        public Node tail;

        // method to add values
        public void Add(T Value)
        {
            Node newNode = new Node { Value = Value };
            if (head == null) // if head is null then a new list is created
            {
                head = newNode;
                tail = newNode;
            }
            else // if not then a tail is added
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
        }

        public IEnumerator<T> GetEnumerator() // <T> --> list of t -- allows for different datatypes
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator(); // checks compatability
        }

        public int IndexOf(T value) // 
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                // it needs to compare the 2 values
                if (EqualityComparer<T>.Default.Equals(current.Value, value)) // compares current value to the node you are moving it to
                    return index;
                index++;
                current = current.Next;

                // once the position --> is item is sorted
                // take away that slot as avail
            }
            return index - 1;
        }

        // method to move node
        public void Move(int sourceIndex, int destinationIndex)
        {
            //checks while you move things around in this list?
            if (sourceIndex < 0 || sourceIndex >= Count || destinationIndex < 0 || destinationIndex >= Count)
                return;

            Node sourceNode = GetNodeAtIndex(sourceIndex); // will add the method in a bit
            Node destNode = GetNodeAtIndex(destinationIndex); // will add the method in a bit

            T temp = sourceNode.Value;
            sourceNode.Value = destNode.Value; // flipping them around
            destNode.Value = temp;  // flipping them around
        }

        // method to clear the node
        public void Clear()
        {
            Node current = head;

            while (current != null)
            {
                Node temp = current;
                current = current.Next;
                temp = null; // Ensure the node is garbage collected
            }

            head = null;
            tail = null;
        }


        private Node GetNodeAtIndex(int index)
        {
            // right click and choose generate method above
            // remove the throws exception
            Node current = head;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }

            return current;
        }

        // get index count
        public int Count
        {
            get
            {
                int count = 0;
                Node current = head;
                while (current != null)
                {
                    count++;
                    current = current.Next;
                }
                return count;
            }
        }

        // method to sort the sorted listbox
        /*
         * the algorithm we used for the sorting below is the Bubble Sort algorithm
         *      - as we compared the nodes in their current order
         *      - then we swopped them if they were in the wrong order
         */
        public void Sort()
        {
            // list for temp storage
            List<Node> nodeList = new List<Node>();
            Node current = head;

            // checks current node status
            while (current != null)
            {
                nodeList.Add(current);
                current = current.Next;
            }

            // this is where the bubble sort takes place
            int n = nodeList.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    int xNumeric = ExtractNumericValue(nodeList[j].Value);
                    int yNumeric = ExtractNumericValue(nodeList[j + 1].Value);

                    if (xNumeric > yNumeric)
                    {
                        // swap the nodes --> if they were in the wromg order
                        Node temp = nodeList[j];
                        nodeList[j] = nodeList[j + 1];
                        nodeList[j + 1] = temp;
                    }
                }
            }

            head = nodeList.First();
            tail = nodeList.Last();

            for (int i = 0; i < nodeList.Count; i++)
            {
                nodeList[i].Previous = (i > 0) ? nodeList[i - 1] : null;
                nodeList[i].Next = (i < nodeList.Count - 1) ? nodeList[i + 1] : null;
            }
        }

        private int ExtractNumericValue(T value)
        {
            // convert the value to a string and extract the first three numeric characters
            string stringValue = value.ToString();
            string numericPart = string.Concat(stringValue.TakeWhile(char.IsDigit));

            if (int.TryParse(numericPart, out int result))
                return result;

            return int.MaxValue; // return a high value if parsing fails
        }
    }


}
