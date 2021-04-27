using System;

namespace Arts_Project
{
    public class PageChangingEventArgs : EventArgs
    {
            //<summary>
            //Hello World   
            //</summary>
            public PageChangingEventArgs(System.Windows.Controls.Page targetpage)
            {
                TargetPage = targetpage;
            }

            public System.Windows.Controls.Page TargetPage { get; set; }
    }
}
