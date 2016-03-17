using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ID3DecisionTree
{
    public class DecisionTree
    {
        private DataTable mSamples;
        private int mTotalPositives = 0;
        private int mTotal = 0;
        private string mTargetAttribute = "";
        private double mEntropySet = 0.0;

        public string TargetAttribute { get { return mTargetAttribute; } set { mTargetAttribute = value; } }
        private int countTotalPositives(DataTable samples)
        {
            int result = 0;

            foreach (DataRow aRow in samples.Rows)
            {
                if (Convert.ToBoolean(aRow[mTargetAttribute].ToString().ToLower()) == true)
                    result++;
            }

            return result;
        }


        private double calcEntropy(int positives, int negatives)
        {
            int total = positives + negatives;
            double ratioPositive = (double)positives / ((total==0)? 1 : total);
            double ratioNegative = (double)negatives / ((total == 0) ? 1 : total);

            
            if (ratioPositive != 0)
                ratioPositive = -(ratioPositive) * System.Math.Log(ratioPositive, 2);
            if (ratioNegative != 0)
                ratioNegative = -(ratioNegative) * System.Math.Log(ratioNegative, 2);

            double result = ratioPositive + ratioNegative;

            return result;
        }

        private void getValuesToAttribute(DataTable samples, Attribute attribute, string value, out int positives, out int negatives)
        {
            positives = 0;
            negatives = 0;

            foreach (DataRow aRow in samples.Rows)
            {
                if ((Convert.ToString(aRow[attribute.AttributeName]) == value))
                    if (Convert.ToBoolean(aRow[mTargetAttribute].ToString().ToLower()) == true)
                        positives++;
                    else
                        negatives++;
            }
        }

        public double gain(DataTable samples, Attribute attribute)
        {
            string[] values = attribute.values;
            mTotal = samples.Rows.Count;
            double sum = 0.0;

            for (int i = 0; i < values.Length; i++)
            {
                int positives, negatives;

                positives = negatives = 0;

                getValuesToAttribute(samples, attribute, values[i], out positives, out negatives);

                double entropy = calcEntropy(positives, negatives);
                sum += -(double)(positives + negatives) / mTotal * entropy;
            }
            return mEntropySet + sum;
        }



        private Attribute getBestAttribute(DataTable samples, Attribute[] attributes)
        {
            double maxGain = 0.0;
            Attribute result = null;

            foreach (Attribute attribute in attributes)
            {
                if (attribute.AttributeName != mTargetAttribute)
                {
                    double aux = gain(samples, attribute);
                    if (aux > maxGain)
                    {
                        maxGain = aux;
                        result = attribute;
                    }
                }
            }
            return result;
        }

        private bool allSamplesPositives(DataTable samples, string targetAttribute)
        {
            foreach (DataRow row in samples.Rows)
            {
                if (Convert.ToBoolean(row[targetAttribute].ToString().ToLower()) == false)
                    return false;
            }

            return true;
        }

        private bool allSamplesNegatives(DataTable samples, string targetAttribute)
        {
            foreach (DataRow row in samples.Rows)
            {
                if (Convert.ToBoolean(row[targetAttribute].ToString().ToLower()) == true)
                    return false;
            }

            return true;
        }

        private ArrayList getDistinctValues(DataTable samples, string targetAttribute)
        {
            ArrayList distinctValues = new ArrayList(samples.Rows.Count);

            foreach (DataRow row in samples.Rows)
            {
                if (distinctValues.IndexOf(row[targetAttribute]) == -1)
                    distinctValues.Add(row[targetAttribute]);
            }

            return distinctValues;
        }

        private object getMostCommonValue(DataTable samples, string targetAttribute)
        {
            ArrayList distinctValues = getDistinctValues(samples, targetAttribute);
            int[] count = new int[distinctValues.Count];

            foreach (DataRow row in samples.Rows)
            {
                int index = distinctValues.IndexOf(row[targetAttribute]);
                count[index]++;
            }

            int MaxIndex = 0;
            int MaxCount = 0;

            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > MaxCount)
                {
                    MaxCount = count[i];
                    MaxIndex = i;
                }
            }

            return distinctValues[MaxIndex];
        }


        private ID3TreeNode internalMountTree(DataTable samples, string targetAttribute, Attribute[] attributes)
        {
            if (allSamplesPositives(samples, targetAttribute) == true)
                return new ID3TreeNode(new Attribute(true));

            if (allSamplesNegatives(samples, targetAttribute) == true)
                return new ID3TreeNode(new Attribute(false));

            if (attributes.Length == 0)
                return new ID3TreeNode(new Attribute(getMostCommonValue(samples, targetAttribute)));

            mTotal = samples.Rows.Count;
            mTargetAttribute = targetAttribute;
            mTotalPositives = countTotalPositives(samples);

            mEntropySet = calcEntropy(mTotalPositives, mTotal - mTotalPositives);

            Attribute bestAttribute = getBestAttribute(samples, attributes);

            if (bestAttribute == null)
                return new ID3TreeNode(new Attribute(getMostCommonValue(samples, targetAttribute)));

            
            
            ID3TreeNode root = new ID3TreeNode(bestAttribute);
            
            DataTable aSample = samples.Clone();

            foreach (string value in bestAttribute.values)
            {

                aSample.Rows.Clear();

                DataRow[] rows = samples.Select(bestAttribute.AttributeName + " = " + "'" + value + "'");

                foreach (DataRow row in rows)
                {
                    aSample.Rows.Add(row.ItemArray);
                }



                ArrayList aAttributes = new ArrayList(attributes.Length - 1);
                for (int i = 0; i < attributes.Length; i++)
                {
                    if (attributes[i].AttributeName != bestAttribute.AttributeName)
                        aAttributes.Add(attributes[i]);
                }


                if (aSample.Rows.Count == 0)
                {
                    return new ID3TreeNode(new Attribute(true));
                }
                else
                {
                    DecisionTree dc3 = new DecisionTree();
                    ID3TreeNode ChildNode = dc3.mountTree(aSample, targetAttribute, (Attribute[])aAttributes.ToArray(typeof(Attribute)));
                    root.AddTreeNode(ChildNode, value);
                }
            }

            return root;
        }

        public ID3TreeNode mountTree(DataTable samples, string targetAttribute, Attribute[] attributes)
        {
            mSamples = samples;
            return internalMountTree(mSamples, targetAttribute, attributes);
        }
    }
}
