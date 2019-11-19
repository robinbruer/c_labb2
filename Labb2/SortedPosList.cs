using System;
using System.Collections.Generic;

namespace Labb2
{
    public class SortedPosList
    {

        private List<Position> PosList = new List<Position>();

        public Position this[int i]
        {
            get { return PosList[i]; }
        }

        public int Count() => PosList.Count;

        public void Add(Position pos)
        {
            if (PosList.Count < 1)
            {
                PosList.Add(pos);
            }
            else
            {
                for (int i = 0; i < PosList.Count; i++)
                {
                    if (PosList[i] > pos)
                    {
                        PosList.Insert(i, pos);
                        break;
                    }
                    if (i == PosList.Count - 1)
                    {
                        PosList.Add(pos);
                        break;
                    }
                }
            }
        }

        public bool Remove(Position pos)
        {
            foreach (var position in PosList)
            {
                if (position.Equals(pos))
                {
                    PosList.Remove(position);
                    return true;
                }
            }
            return false;
        }

        public SortedPosList Clone()
        {
            SortedPosList clonedList = new SortedPosList();
            foreach (var position in PosList)
            {
                clonedList.Add(position.Clone());
            }
            return clonedList;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList cloneList = Clone();
            foreach (var pos in PosList)
            {
                if ((Math.Pow(pos.X - centerPos.X, 2) + Math.Pow(pos.Y - centerPos.Y, 2)) > Math.Pow(radius, 2))
                {
                    cloneList.Remove(pos);
                }
            }
            return cloneList;
        }

        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList newList = sp1.Clone();
            for (int i = 0; i < sp2.Count(); i++)
            {
                newList.Add(sp2[i]);
            }
            return newList;
        }

        public static SortedPosList operator -(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList newList = sp1.Clone();

            int i = 0;
            int j = 0;

            while (i < sp1.Count() && j < sp2.Count())
            {
                if (sp1[i].Equals(sp2[j]))
                {
                    newList.Remove(sp1[i]);
                    i++;
                    j++;
                }
                else if (sp1[i] < sp2[j])
                {
                    i++;
                }
                else if (sp1[i] > sp2[j])
                {
                    j++;
                }
            }

            return newList;
        }

        public override string ToString()
        {
            return string.Join(", ", PosList);
        }

    }
}