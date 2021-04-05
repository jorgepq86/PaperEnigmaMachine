using System;
using System.Collections.Generic;
using Autofac.Features.Indexed;
using PaperEnigma.Logic.Abstractions;
using PaperEnigma.Logic.Enums;

namespace PaperEnigma.Logic
{
    public class DachpcPaperEnigmaMachine : IPaperEnigmaMachine
    {
        public List<string> InputOutputData => new List<string>
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U",
            "V", "W", "X", "Y", "Z"
        };

        public List<string> ReflectorData => new List<string>
        {
            "A", "B", "C", "D", "E", "F", "G", "D", "I", "J", "K", "G", "M", "K", "M", "I", "E", "B", "F", "T", "C", "V",
            "V", "J", "A", "T"
        };
        
        private readonly IRotor _rotorOne;
        private readonly IRotor _rotorTwo;
        private readonly IRotor _rotorThree;


        public DachpcPaperEnigmaMachine(IIndex<RotorNumber, IRotor> rotorFactory)
        {
            _rotorOne = rotorFactory[RotorNumber.RotorOne];
            _rotorTwo = rotorFactory[RotorNumber.RotorTwo];
            _rotorThree = rotorFactory[RotorNumber.RotorThree];
        }

        public void SetInitialSettings(string initialSettings)
        {
            char initialOne = initialSettings[0];
            char initialTwo = initialSettings[1];
            char initialThree = initialSettings[2];
            
            _rotorOne.SetInitialValue(initialOne.ToString());
            _rotorTwo.SetInitialValue(initialTwo.ToString());
            _rotorThree.SetInitialValue(initialThree.ToString());
        }

        public string DecodeMessage(string message)
        {
            var returnMessage = string.Empty;

            try
            {
                foreach (char letter in message)
                {
                    if (letter == ' ')
                    {
                        returnMessage += " ";
                        continue;
                    }
                    
                    int inputIndex = GetInputOutputIndex(letter.ToString());
                    int oneWayIndex = GetOneWayIndex(inputIndex);
                    int reflectorIndex = GetReflectorIndex(oneWayIndex);
                    int returnIndex = GetReturnIndex(reflectorIndex);
                    string decodedLetter = InputOutputData[returnIndex];
                    returnMessage += decodedLetter;
                    Console.WriteLine($"Letter {letter} decoded to {decodedLetter}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return returnMessage;
        }

        private int GetInputOutputIndex(string letter) => InputOutputData.FindIndex(i => i == letter);

        private int GetOneWayIndex(int inputIndex)
        {
            int rotorThreeIndex = _rotorThree.GetOneWayIndex(inputIndex);
            _rotorThree.NextRotorShift(_rotorTwo); 
            int rotorTwoIndex = _rotorTwo.GetOneWayIndex(rotorThreeIndex);
            _rotorTwo.NextRotorShift(_rotorOne);
            return _rotorOne.GetOneWayIndex(rotorTwoIndex);
        }

        private int GetReflectorIndex(int index)
        {
            string indexLetter = ReflectorData[index];
            int reflectorIndex = ReflectorData.FindIndex(r => r == indexLetter);
            if (reflectorIndex == index)
                reflectorIndex = ReflectorData.FindIndex(reflectorIndex + 1, r => r == indexLetter);
            return reflectorIndex;
        }

        private int GetReturnIndex(int reflectorIndex)
        {
            int threeIndex = _rotorOne.GetReturnIndex(reflectorIndex);
            int secondIndex = _rotorTwo.GetReturnIndex(threeIndex);
            return _rotorThree.GetReturnIndex(secondIndex);
        }
    }
}