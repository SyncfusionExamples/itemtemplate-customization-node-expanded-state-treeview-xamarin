# How to customize TreeView ItemTemplate based on the node expanded state in Xamarin.Forms (SfTreeView)

You can customize the TreeView ItemTemplate based on the node whether the node is expanded or not in Xamarin.Forms SfTreeView by DataTemplateSelector.

You can also refer the following article.

https://www.syncfusion.com/kb/11394/how-to-customize-treeview-itemtemplate-based-on-the-node-expanded-state-in-xamarin-forms

**C#**

Changing the node Template at runtime by using OnSelectTemplate method based on node expanded state.
``` c#
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
```

**XAML**

DataTemplateSelector bound to ItemTemplate property.
``` xml
<ContentPage.Resources>
    <ResourceDictionary>
        <local:ItemTemplateSelector x:Key="ItemTemplateSelector" />
    </ResourceDictionary>
</ContentPage.Resources>
 
<StackLayout Orientation="Vertical" Padding="5">
    <syncfusion:SfTreeView x:Name="treeView" NotificationSubscriptionMode="CollectionChange,PropertyChange"  
                            ItemHeight="40"
                            Indentation="15"
                            ExpanderWidth="40"
                            ChildPropertyName="SubFiles"
                            ItemsSource="{Binding ImageNodeInfo}"
                            ItemTemplate="{StaticResource ItemTemplateSelector}"
                            AutoExpandMode="AllNodesExpanded">
    </syncfusion:SfTreeView>
</StackLayout>
```

**Output**

![ExpandedStateBasedItemTemplate](https://github.com/SyncfusionExamples/itemtemplate-customization-node-expanded-state-treeview-xamarin/blob/master/ScreenShots/ExpandedStateBasedItemTemplate.gif)
