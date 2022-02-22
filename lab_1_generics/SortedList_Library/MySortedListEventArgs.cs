using System;

namespace SortedList_Library
{
    
    public class MySortedListEventArgs : EventArgs
    {
        public MySortedListEventArgs(string action, string item)
        {
            Action = action;
            Item = item;
        }
        public string Action { get; }
        public string Item { get; }
    }
    
}