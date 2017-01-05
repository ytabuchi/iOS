// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace UITableViewSample.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView CustomTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton GetSpeakersButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CustomTableView != null) {
                CustomTableView.Dispose ();
                CustomTableView = null;
            }

            if (GetSpeakersButton != null) {
                GetSpeakersButton.Dispose ();
                GetSpeakersButton = null;
            }
        }
    }
}