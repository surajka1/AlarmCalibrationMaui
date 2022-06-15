using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace MauiApp2.Models
{

    public static class ResistorManipulateClass
    {
        private static HashSet<long> _resistorvalues = new HashSet<long>();

        public static HashSet<long> GetResValuesFromJson()
        {
            string jsonpath = AppDomain.CurrentDomain.BaseDirectory + "ResValues.json";
            if (File.Exists(jsonpath))
            {
                string jsonReadFromFile = File.ReadAllText(jsonpath);
                _resistorvalues = JsonSerializer.Deserialize<HashSet<long>>(jsonReadFromFile) ?? _resistorvalues;
            }
            return _resistorvalues;
        }

        public static void Add(long value)
        {
            _resistorvalues.Add(value);
            string jsonpath = AppDomain.CurrentDomain.BaseDirectory + "ResValues.json";
            string jsontoWrite = JsonSerializer.Serialize(_resistorvalues);
            File.WriteAllText(jsonpath, jsontoWrite);
        }
        public static void Remove(long vallue)
        {
            _resistorvalues.Remove(vallue);
            string jsonpath = AppDomain.CurrentDomain.BaseDirectory + "ResValues.json";
            string jsontoWrite = JsonSerializer.Serialize(_resistorvalues);
            File.WriteAllText(jsonpath, jsontoWrite);
        }

        public static Dictionary<long, ResChildren> FindResistorValues(long resvalueInput, long resvalOffset, out long minTolerance)
        {
            minTolerance = 0;
            Dictionary<long, ResChildren> outputResistorList = new Dictionary<long, ResChildren>();
            long tolerance = 0;
            HashSet<long> allresvalues = ResistorManipulateClass.GetResValuesFromJson();

            resvalueInput = resvalueInput - resvalOffset;

            if (!(allresvalues?.Count > 0))
                return outputResistorList;

            while (outputResistorList.Count < 1)
            {
                foreach (var parent in allresvalues)
                {
                    if (parent > resvalueInput)
                        continue;

                    foreach (var child1 in allresvalues)
                    {
                        long tempOutVal = parent + child1;
                        if ((tempOutVal >= (resvalueInput - tolerance)) && (tempOutVal <= (resvalueInput + tolerance)))
                        {
                            if (!outputResistorList.ContainsKey(parent))
                                outputResistorList.Add(parent, new ResChildren(child1, long.MaxValue, tempOutVal));
                        }
                        foreach (var child2 in allresvalues)
                        {
                            tempOutVal = parent + (child1 * child2) / (child1 + child2);
                            if ((tempOutVal >= (resvalueInput - tolerance)) && (tempOutVal <= (resvalueInput + tolerance)))
                            {
                                if (!outputResistorList.ContainsKey(parent))
                                    outputResistorList.Add(parent, new ResChildren(child1, child2, tempOutVal));
                                //outputResistorList.Add(new OutPutResistors(parent, child1, child2, tempOutVal));
                            }
                        }
                    }
                }
                tolerance++;
            }

            minTolerance = tolerance;
            return outputResistorList;
        }

        public static Dictionary<long, ResChildren> FindResistorValues(long resvalueInput, out long minTolerance)
        {
            return FindResistorValues(resvalueInput, 0, out minTolerance);
        }

        public static string ResValueToString(long value)
        {
            string Parent = string.Empty;
            if (value == long.MaxValue)
            {
                Parent = "∞";
            }
            else if (value < 999)
            {
                Parent = value.ToString() + "E";
            }
            else if (value < 999999)
            {
                Parent = ((float)value / 1000f).ToString() + "K";
            }
            else
            {
                Parent = ((float)value / 1000000f).ToString() + "M";
            }
            return Parent;
        }
    }

    public class ResChildren
    {
        public long child1 = 0;
        public long child2 = 0;
        public long OutputValue = 0;
        public ResChildren(long child1, long child2, long outputValue)
        {
            this.child1 = child1;
            this.child2 = child2;
            OutputValue = outputValue;
        }
    }

    public class OutPutResistors
    {
        public long parent = 0;
        public long child1 = 0;
        public long child2 = 0;
        public long OutputValue = 0;


        public OutPutResistors(long val1, long val2, long val3, long outputValue)
        {
            parent = val1;
            child1 = val2;
            child2 = val3;
            OutputValue = outputValue;
        }
    }

    public class InputValidation
    {
        public bool validateStatus = false;
        public string? errorMessage = string.Empty;
        public long potMaxValue = 0;
        public long potMaxValAtMark = 0;
        public long potLowerOffset = 0;
    }
}
