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
            if (!long.TryParse(higherOffset, out inputValidation.potHigherOffset))
            {
                inputValidation.errorMessage = "Error parsing higher offset value!";
                return inputValidation;
            }
            if (!(inputValidation.potMaxValue > inputValidation.potHigherOffset))
            {
                inputValidation.errorMessage = "Maximum Pot value and Higher Offset do not match.";
                return inputValidation;
            }
            if (inputValidation.potMaxValue < (standardValue * .5) || inputValidation.potMaxValue > (standardValue * 1.5) || inputValidation.potHigherOffset < (standardValue * .5) || inputValidation.potHigherOffset > (standardValue * 1.5) || inputValidation.potLowerOffset > (standardValue * .5))
            {
                inputValidation.errorMessage = "Too bad a POT to calculate the values.";
                return inputValidation;
            }
            if (inputValidation.potMaxValue < (standardValue*.7) || inputValidation.potMaxValue > (standardValue*1.3) || inputValidation.potHigherOffset < (standardValue*.7) || inputValidation.potHigherOffset > (standardValue*1.3) || inputValidation.potLowerOffset > (standardValue*.3))
            {
                inputValidation.errorMessage = "Too bad a POT to calculate the values.";
                inputValidation.validateStatus = true;
                return inputValidation;
            }

            inputValidation.validateStatus = true;
            return inputValidation;
        }
        public static string GetOutputValuesForDisplay()
        {

            return string.Empty;
        }
    }
}
