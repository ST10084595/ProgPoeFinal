using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProgPoe1
{
    internal class LisstControls
    {

        public static void SwapIndexes(int change, ListBox listBox)
        {

            if (listBox.SelectedItem == null || listBox.SelectedIndex < 0)
            {
                return;
            }
            //target destination 
            int newIndex = listBox.SelectedIndex + change;
            //ensure new Destination exists 
            if (newIndex < 0 || newIndex >= listBox.Items.Count)
            {
                return;
            }


            //object seleted 
            object selected = listBox.SelectedItem;
            //insert into new locaiton 
            listBox.Items.Remove(selected);
            listBox.Items.Insert(newIndex, selected);
            listBox.SelectedIndex = newIndex;

        }
        public static void randomiseList(ListBox listBox)
        {

            //new list type of 
            var list = new List<String>();
            Random rnd = new Random();

            list = listBox.Items.Cast<String>().ToList();

            //shuffle the list of item 
            int n = list.Count;

            while (n > 1)
            {

                int k = rnd.Next(n);
                n--;
                string value = list[k];
                list[k] = list[n];
                list[n] = value;


            }
            listBox.Items.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                listBox.Items.Add(list[i]);
            }

        }

    }
}
