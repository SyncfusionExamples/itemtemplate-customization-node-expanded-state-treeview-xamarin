using Syncfusion.TreeView.Engine;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TreeViewXamarin
{
    public class ItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate RootNodeTemplate { get; set; }
        public DataTemplate ChildNodeTemplate { get; set; }

        public DataTemplate CollapsedTemplate { get; set; }

        public ItemTemplateSelector()
        {
            this.RootNodeTemplate = new DataTemplate(typeof(RootNodeTemplate));
            this.ChildNodeTemplate = new DataTemplate(typeof(ChildNodeTemplate));
            this.CollapsedTemplate = new DataTemplate(typeof(CollapsedTemplate));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var treeviewNode = item as TreeViewNode;
            if (treeviewNode == null)
                return null;
            if (!treeviewNode.IsExpanded && treeviewNode.HasChildNodes && treeviewNode.Level == 0)
                return this.CollapsedTemplate;
            else if (treeviewNode.Level == 0)
                return this.RootNodeTemplate;
            else
                return this.ChildNodeTemplate;
        }
    }
}
