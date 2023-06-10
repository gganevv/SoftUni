﻿namespace TaskBoardApp.Data
{
    public static class DataConstants
    {
        public static class Task
        {
            public const int TaskMinTitle = 5;
            public const int TaskMaxTitle = 70;

            public const int TaskMinDescription = 10;
            public const int TaskMaxDescription = 1000;
        }

        public static class Board
        {
            public const int BoardMinName = 3;
            public const int BoardMaxName = 30;
        }
    }
}
