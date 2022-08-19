using System;

namespace BlackBearsTask {
    internal class Program {

        private static string[,] _strings = new string[4, 9]
        {
            {"_","*","_","_","_","_","_","_","_"},
            {"*","_","_","_","*","_","*","_","_"},
            {"_","*","_","_","*","*","*","_","*"},
            {"*","*","_","*","*","*","*","_","*"},
        };

        private static int[] _counts = new int[4];

        public static void Main(string[] args) {
            var rows = _strings.GetUpperBound(0) + 1;
            var columns = _strings.Length / rows;
            PrintInfo(rows, columns);
            InitializeCounts(rows, columns);
            BuildTree(rows, columns);
            PrintInfo(rows, columns);
        }

        public static void InitializeCounts(int rows, int columns) {
            for (int idRow = 0; idRow < rows; idRow++) {
                for (int idColumn = 0; idColumn < columns; idColumn++) {
                    if (_strings[idRow, idColumn] == "*") {
                        _counts[idRow]++;
                    }
                }
            }
        }

        public static void BuildTree(int rows, int columns) {
            for (int idRow = 0; idRow < rows; idRow++) {
                var centerIndex = columns / 2;
                var centerOffset = _counts[idRow] / 2;
                var startIndex = centerIndex - centerOffset;
                var stopIndex = centerIndex + centerOffset;
                
                for (int idColumn = 0; idColumn < columns; idColumn++) {
                    if (idColumn < stopIndex || idColumn > stopIndex) {
                        if (_strings[idRow, idColumn] == "*") {
                            for (int i = startIndex; i <= stopIndex; i++) {
                                if (_strings[idRow, i] == "_") {
                                    _strings[idRow, i] = "*";
                                    _strings[idRow, idColumn] = "_";
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void PrintInfo(int rows, int columns) {
            for (int idRow = 0; idRow < rows; idRow++) {
                for (int idColumn = 0; idColumn < columns; idColumn++) {
                    Console.Write($"{_strings[idRow, idColumn]} ");
                }
                Console.WriteLine();
            }
        }
    }
}