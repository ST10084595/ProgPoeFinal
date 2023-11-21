using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPoe1
{
    public class treeNode : IEnumerable<treeNode>
    {

        //variables

        private readonly Dictionary<string, treeNode> _children = new Dictionary<string, treeNode>();



        public readonly string ID;



        public treeNode Parent { get; private set; }



        public treeNode(string id)

        {

            this.ID = id;

        }



        public treeNode GetChild(string id)

        {

            return this._children[id];

        }



        public void Add(treeNode item)

        {

            if (item.Parent != null)

            {

                item.Parent._children.Remove(item.ID);

            }



            item.Parent = this;

            this._children.Add(item.ID, item);

        }









        public int Count

        {

            get { return this._children.Count; }

        }



        public static treeNode BuildTree(string[] tree)

        {

            var result = new treeNode("TreeRoot");

            var list = new List<treeNode> { result };



            foreach (var line in tree)

            {

                var trimmedLine = line.Trim();

                var indent = line.Length - trimmedLine.Length;



                var child = new treeNode(trimmedLine);

                list[indent].Add(child);



                if (indent + 1 < list.Count)

                {

                    list[indent + 1] = child; 



                }

                else

                {

                    list.Add(child);

                }

            }

            return result;

        }

        IEnumerator IEnumerable.GetEnumerator()

        {

            return this.GetEnumerator();

        }



        public IEnumerator<treeNode> GetEnumerator()

        {

            return this._children.Values.GetEnumerator();

        }
    }
}
