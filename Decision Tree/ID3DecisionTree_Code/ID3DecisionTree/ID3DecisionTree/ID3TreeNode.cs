using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ID3DecisionTree
{
    public class ID3TreeNode
    {
        private ArrayList mChilds = null;
        private Attribute mAttribute;

        public ID3TreeNode(Attribute attribute)
        {
            if (attribute.values != null)
            {
                mChilds = new ArrayList(attribute.values.Length);
                for (int i = 0; i < attribute.values.Length; i++)
                    mChilds.Add(null);
            }
            else
            {
                mChilds = new ArrayList(1);
                mChilds.Add(null);
            }
            mAttribute = attribute;
        }

        public void AddTreeNode(ID3TreeNode treeNode, string ValueName)
        {
            int index = mAttribute.indexValue(ValueName);
            mChilds[index] = treeNode;
        }

        public int totalChilds
        {
            get
            {
                return mChilds.Count;
            }
        }

        public ID3TreeNode getChild(int index)
        {
            return (ID3TreeNode)mChilds[index];
        }

        public Attribute attribute
        {
            get
            {
                return mAttribute;
            }
        }

        public ID3TreeNode getChildByBranchName(string branchName)
        {
            int index = mAttribute.indexValue(branchName);
            return (ID3TreeNode)mChilds[index];
        }

        public void PrintPretty(string indent)
        {
            Console.WriteLine(this.attribute);
            if (this.attribute.values != null)
            {
                for (int i = 0; i < this.attribute.values.Length; i++)
                {
                    Console.Write(indent);
                    string write = string.Format("|---- {0} ----", this.attribute.values[i]);
                    Console.Write(write);
                    var x = this.getChild(i);
                    this.getChild(i).PrintPretty(indent + "".PadRight(write.Length, ' '));
                }
            }
        }

        public void PrintPrettyToFile(StreamWriter writer, string indent)
        {
            writer.WriteLine(this.attribute);
            if (this.attribute.values != null)
            {
                for (int i = 0; i < this.attribute.values.Length; i++)
                {
                    writer.Write(indent);
                    string write = string.Format("|---- {0} ----", this.attribute.values[i]);
                    writer.Write(write);
                    var x = this.getChild(i);
                    this.getChild(i).PrintPrettyToFile(writer, indent + "".PadRight(write.Length, ' '));
                }
            }
        }
    }
}
