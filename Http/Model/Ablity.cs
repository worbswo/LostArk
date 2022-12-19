using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Http.Model
{
    public class Ablity
    {
        #region Field
        #endregion

        #region Property
        public Dictionary<string, int> TargetItems { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, List<int>> EquipItems { get; set; } = new Dictionary<string, List<int>>();
        public Dictionary<string, int> PanaltyItems { get; set; } = new Dictionary<string, int>();
        public List<SearchAblity> SearchAblities { get; set; }=new List<SearchAblity>();
        public int selectClass { get; set; } = 1;
        public Dictionary<string,List<int>> FirstAblityCandidate { get; set; } = new Dictionary<string, List<int>>();
        public Dictionary<string, List<int>> SecondAblityCandidate { get; set; } = new Dictionary<string, List<int>>();
#endregion

#region Method
        public void ComputeAblity() 
        {
       
            for (int i = 0; i < EquipItems.Count; i++)
            {
                for (int j = 0; j < EquipItems[EquipItems.Keys.ToList()[i]].Count; j++)
                {
                    TargetItems[EquipItems.Keys.ToList()[i]] -= EquipItems[EquipItems.Keys.ToList()[i]][j];
                }
            }
            int cnt = 0;
            if (selectClass == 0)
            {
                
                for (int i = 0; i < TargetItems.Count; i++)
                {
                    while (true)
                    {
                        if (TargetItems[TargetItems.Keys.ToList()[i]] / 5 > 0 )
                        {
                            cnt++;
                            if (FirstAblityCandidate.ContainsKey(TargetItems.Keys.ToList()[i]))
                            {
                                FirstAblityCandidate[TargetItems.Keys.ToList()[i]].Add(5);
                            }
                            else
                            {
                                FirstAblityCandidate.Add(TargetItems.Keys.ToList()[i], new List<int> { 5 });
                            }
                            TargetItems[TargetItems.Keys.ToList()[i]] -= 5;
                        }
                        else if(TargetItems[TargetItems.Keys.ToList()[i]] / 4 > 0)
                        {
                            cnt++;
                            if (FirstAblityCandidate.ContainsKey(TargetItems.Keys.ToList()[i]))
                            {
                                FirstAblityCandidate[TargetItems.Keys.ToList()[i]].Add(4);
                            }
                            else
                            {
                                FirstAblityCandidate.Add(TargetItems.Keys.ToList()[i], new List<int> { 4 });
                            }
                            TargetItems[TargetItems.Keys.ToList()[i]] -= 4;

                           
                        }
                        else if(TargetItems[TargetItems.Keys.ToList()[i]]>0)
                        {
                            
                            if (SecondAblityCandidate.ContainsKey(TargetItems.Keys.ToList()[i]))
                            {
                                SecondAblityCandidate[TargetItems.Keys.ToList()[i]].Add(TargetItems[TargetItems.Keys.ToList()[i]]);
                            }
                            else
                            {
                                SecondAblityCandidate.Add(TargetItems.Keys.ToList()[i], new List<int> { TargetItems[TargetItems.Keys.ToList()[i]] });
                            }
                            break;
                        }else
                        {
                            break;
                        }
                    }
                }
                for (int i = 0; i < FirstAblityCandidate.Count; i++)
                {
                    Console.Write(FirstAblityCandidate.Keys.ToList()[i]+ " : ");
                    for (int j = 0; j < FirstAblityCandidate[FirstAblityCandidate.Keys.ToList()[i]].Count; j++)
                    {
                        Console.Write(FirstAblityCandidate[FirstAblityCandidate.Keys.ToList()[i]][j] + " , ");
                    }
                    Console.WriteLine("");

                }
                Console.WriteLine("----------------------------");
                for (int i = 0; i < SecondAblityCandidate.Count; i++)
                {
                    Console.Write(SecondAblityCandidate.Keys.ToList()[i] + " : ");
                    for (int j = 0; j < SecondAblityCandidate[SecondAblityCandidate.Keys.ToList()[i]].Count; j++)
                    {
                        Console.Write(SecondAblityCandidate[SecondAblityCandidate.Keys.ToList()[i]][j] + " , ");
                    }
                    Console.WriteLine("");

                }


            }
            else
            {
                for (int i = 0; i < TargetItems.Count; i++)
                {
                   
                    while (true)
                    {
                        if (TargetItems[TargetItems.Keys.ToList()[i]] / 6 > 0)
                        {
                            cnt++;
                            if (FirstAblityCandidate.ContainsKey(TargetItems.Keys.ToList()[i]))
                            {
                                FirstAblityCandidate[TargetItems.Keys.ToList()[i]].Add(6);
                            }
                            else
                            {
                                FirstAblityCandidate.Add(TargetItems.Keys.ToList()[i], new List<int> { 6 });
                            }
                            TargetItems[TargetItems.Keys.ToList()[i]] -= 6;
                        }
                        else if (TargetItems[TargetItems.Keys.ToList()[i]] / 5 > 0)
                        {
                            cnt++;
                            if (FirstAblityCandidate.ContainsKey(TargetItems.Keys.ToList()[i]))
                            {
                                FirstAblityCandidate[TargetItems.Keys.ToList()[i]].Add(5);
                            }
                            else
                            {
                                FirstAblityCandidate.Add(TargetItems.Keys.ToList()[i], new List<int> { 5 });
                            }
                            TargetItems[TargetItems.Keys.ToList()[i]] -= 5;


                        }
                        else if (TargetItems[TargetItems.Keys.ToList()[i]] / 4 > 0)
                        {
                            cnt++;
                            if (FirstAblityCandidate.ContainsKey(TargetItems.Keys.ToList()[i]))
                            {
                                FirstAblityCandidate[TargetItems.Keys.ToList()[i]].Add(4);
                            }
                            else
                            {
                                FirstAblityCandidate.Add(TargetItems.Keys.ToList()[i], new List<int> { 4 });
                            }
                            TargetItems[TargetItems.Keys.ToList()[i]] -= 4;
                        }
                        else if (TargetItems[TargetItems.Keys.ToList()[i]] > 0)
                        {

                            if (SecondAblityCandidate.ContainsKey(TargetItems.Keys.ToList()[i]))
                            {
                                SecondAblityCandidate[TargetItems.Keys.ToList()[i]].Add(TargetItems[TargetItems.Keys.ToList()[i]]);
                            }
                            else
                            {
                                SecondAblityCandidate.Add(TargetItems.Keys.ToList()[i], new List<int> { TargetItems[TargetItems.Keys.ToList()[i]] });
                            }
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                for (int i = 0; i < FirstAblityCandidate.Count; i++)
                {
                    Console.Write(FirstAblityCandidate.Keys.ToList()[i] + " : ");
                    for (int j = 0; j < FirstAblityCandidate[FirstAblityCandidate.Keys.ToList()[i]].Count; j++)
                    {
                        Console.Write(FirstAblityCandidate[FirstAblityCandidate.Keys.ToList()[i]][j] + " , ");
                    }
                    Console.WriteLine("");

                }
                Console.WriteLine("----------------------------");
                for (int i = 0; i < SecondAblityCandidate.Count; i++)
                {
                    Console.Write(SecondAblityCandidate.Keys.ToList()[i] + " : ");
                    for (int j = 0; j < SecondAblityCandidate[SecondAblityCandidate.Keys.ToList()[i]].Count; j++)
                    {
                        Console.Write(SecondAblityCandidate[SecondAblityCandidate.Keys.ToList()[i]][j] + " , ");
                    }
                    Console.WriteLine("");

                }
            }
            if (cnt > 5)
            {
                MessageBox.Show("구성할 수 없는 각인 입니다.");
                return;
            }
            else { 

            }
        
        }
        #endregion
    }
}
