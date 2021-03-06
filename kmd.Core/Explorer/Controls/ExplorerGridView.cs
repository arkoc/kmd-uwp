﻿using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace kmd.Core.Explorer.Controls
{
    public class ExplorerGridView : GridView
    {
        public void ForceFocusSelectedItem(FocusState state = FocusState.Keyboard)
        {
            // according to https://stackoverflow.com/questions/10444518/how-do-you-programmatically-set-focus-to-the-selecteditem-in-a-wpf-listbox-that
            // to properly set focus on listview item

            this.UpdateLayout();

            var item = (SelectorItem)ContainerFromItem(this.SelectedItem);
            if (item != null)
            {
                item.Focus(state);
            }
        }

        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            // Stop default behaviour for some keys
            if (e.Key == VirtualKey.Enter)
            {
                return;
            }

            base.OnKeyDown(e);
        }
    }
}
