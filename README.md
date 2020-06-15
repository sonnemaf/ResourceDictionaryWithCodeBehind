# ResourceDictionaryWithCodeBehind
Visual Studio ItemTemplate for a ResourceDictionary with Code-behind which can be used for x:Bind and EventHandlers

This ItemTemplate is published in the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=FonsSonnemans.ResourceDictionaryWithCodeBehindPackage)

![Add New Item dialog](/AddNewItem.png)

# SampleApp
This project also contains a sample app which has a *DataTemplates.xaml* ResourceDictionary with a Code-behind.

## DataTemplates.xaml
This file contains a x:Class attribute in the ResourceDictionary. This class is defined in the Code-behind. It allowes you to use x:Bind markupextensions and eventhandlers.

```xml
<ResourceDictionary x:Class="SampleApp.Views.Resources.DataTemplates"
                    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:models="using:SampleApp.Models">

    <DataTemplate x:Key="EmployeeDataTemplate"
                  x:DataType="models:Employee">
        <StackPanel Padding="4"
                    Loaded="StackPanel_Loaded"
                    Spacing="8">
            <TextBlock FontWeight="Bold"
                       Text="{x:Bind Name}" />
            <TextBlock Text="{x:Bind Salary}" />
        </StackPanel>
    </DataTemplate>

</ResourceDictionary>
```

## DataTemplates.xaml.cs
The generated DataTemplates class is referenced from the xaml file (x:Class). 

```
using Windows.UI.Xaml;

namespace SampleApp.Views.Resources {
    partial class DataTemplates : ResourceDictionary {
        public DataTemplates() {
            this.InitializeComponent();
        }
        
        private void StackPanel_Loaded(object sender, RoutedEventArgs e) {
            // Some code, this is just an example
        }

    }
}
```

## App.xaml
An instance of the DataTemplates is created in the MergedDictionary. There is a *xmlns:resources* defined in the Application element.
```xml
<Application x:Class="SampleApp.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:resources="using:SampleApp.Views.Resources">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <resources:DataTemplates />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

## MainPage.xaml
In the ListView the ItemTemplate is set to *EmployeeDataTemplate*. This Template is defined in the DataTemplates.xaml

```xml
<Page x:Class="SampleApp.Views.Pages.MainPage"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
      xmlns:vm="using:SampleApp.ViewModels"
      Background="{ThemeResource ApplicationPageBackgroundThemeBrush}"
      mc:Ignorable="d">

    <Grid>
        <ListView ItemTemplate="{StaticResource EmployeeDataTemplate}"
                  ItemsSource="{x:Bind vm:MainViewModel.Current.Employees}" />
    </Grid>
</Page>
```
