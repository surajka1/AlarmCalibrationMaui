using MauiApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.ViewModels
{
    internal class ValueCalculation
    {
        public static InputValidation ValidateInput(string potMax, string higherOffset, string lowerOffset, long standardValue)
        {
            InputValidation inputValidation = new InputValidation();

            if (!long.TryParse(lowerOffset, out inputValidation.potLowerOffset))
            {
                inputValidation.errorMessage = "Error parsing lower offset value!";
                return inputValidation;
            }
            if (!long.TryParse(potMax, out inputValidation.potMaxValue))
            {
                inputValidation.errorMessage = "Error parsing POT maximum value!";
                return inputValidation;
            }
            if (!long.TryParse(higherOffset, out inputValidation.potMaxValAtMark))
            {
                inputValidation.errorMessage = "Error parsing higher offset value!";
                return inputValidation;
            }
            if (!(inputValidation.potMaxValue >= inputValidation.potMaxValAtMark))
            {
                inputValidation.errorMessage = "Maximum Pot value and Higher Offset do not match.";
                return inputValidation;
            }
            if (inputValidation.potMaxValue < (standardValue * .5) || inputValidation.potMaxValue > (standardValue * 1.5) || inputValidation.potMaxValAtMark < (standardValue * .5) || inputValidation.potMaxValAtMark > (standardValue * 1.5) || inputValidation.potLowerOffset > (standardValue * .5))
            {
                inputValidation.errorMessage = "Too bad a Preset to calculate the values.";
                return inputValidation;
            }
            if (inputValidation.potMaxValue < (standardValue*.7) || inputValidation.potMaxValue > (standardValue*1.3) || inputValidation.potMaxValAtMark < (standardValue*.7) || inputValidation.potMaxValAtMark > (standardValue*1.3) || inputValidation.potLowerOffset > (standardValue*.3))
            {
                inputValidation.errorMessage = "The Preset is out of normal range. Consider replacing it.";
                inputValidation.validateStatus = true;
                return inputValidation;
            }

            inputValidation.validateStatus = true;
            return inputValidation;
        }
        public static string GetOutputValuesForDisplay(InputValidation inputValidation, ProductModel product)
        {
            StringBuilder outputStrBuilder = new StringBuilder();
            long minToleranceFound = 0;
            long potMaxValueEndToEnd = inputValidation.potMaxValue;
            long lowerOffset = inputValidation.potLowerOffset;
            long higherOffset = inputValidation.potMaxValue - inputValidation.potMaxValAtMark;
            long potMaxValueAtMark = inputValidation.potMaxValAtMark;
            long requiredResValue = 0;
            float multiplier_f = product.UpperMultiplier;

            requiredResValue = (long)((float)potMaxValueEndToEnd * multiplier_f);
            Dictionary<long, ResChildren> outputResistorList = ResistorManipulateClass.FindResistorValues(requiredResValue, higherOffset, out minToleranceFound);
            if (outputResistorList.Count > 0)
            {
                int i = 1;
                outputStrBuilder.Append($"Upper Values. Discrepancy : {minToleranceFound}E\r\n");//\r\n----------------------------------------------------\r\n");

                foreach (var item in outputResistorList)
                {
                    outputStrBuilder.Append($"{i++}.  {product.UpperParent} = {ResistorManipulateClass.ResValueToString(item.Key)}   +   {product.UpperChild1} = {ResistorManipulateClass.ResValueToString(item.Value.child1)}  ||  {product.UpperChild2} = {ResistorManipulateClass.ResValueToString(item.Value.child2)} \r\n");
                }
                //textBox_Output.AppendText($"Minimum Discrepancy : {minToleranceFound}E\r\n");
            }
            outputStrBuilder.Append("\r\n*************************************\r\n\r\n");

            multiplier_f = product.LowerMultiplier;

            requiredResValue = (long)((float)potMaxValueEndToEnd * multiplier_f);
            outputResistorList = ResistorManipulateClass.FindResistorValues(requiredResValue, lowerOffset, out minToleranceFound);
            if (outputResistorList.Count > 0)
            {
                int i = 1;
                outputStrBuilder.Append($"Lower Values. Discrepancy : {minToleranceFound}E\r\n");// Required is {requiredResValue}\r\n----------------------------------------------------\r\n");

                foreach (var item in outputResistorList)
                {
                    outputStrBuilder.Append($"{i++}.  {product.LowerParent} = {ResistorManipulateClass.ResValueToString(item.Key)}   +   {product.LowerChild1} = {ResistorManipulateClass.ResValueToString(item.Value.child1)}  ||  {product.LowerChild2} = {ResistorManipulateClass.ResValueToString(item.Value.child2)} \r\n");
                }
                
            }
            return outputStrBuilder.ToString();
        }
    }
}
