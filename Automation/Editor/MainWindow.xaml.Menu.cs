﻿using System;
using System.Activities.Presentation;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xaml;
using System.Xml.Linq;
using ActivityLib;

namespace Editor
{
    public partial class MainWindow : Window
    {
        #region Main Menu

        private void FileMenuSubmenuOpened(object sender, RoutedEventArgs e)
        {
            //if (ChangeManager.GetInstance().IsChanged())
            //    SaveMenuItem.IsEnabled = true;
            //else
            //    SaveMenuItem.IsEnabled = false;
        }

        private void ClickExitButton(object sender, RoutedEventArgs e)
        {
            //if (ChangeManager.GetInstance().IsChanged())
            //{
            //    string message = "Some Changes has not been saved! ";

            //    message += "\nAre you sure?";
            //    if (MessageBox.Show(message, "Exit Without Saved?", MessageBoxButton.YesNo, MessageBoxImage.Warning) ==
            //        MessageBoxResult.No)
            //        return;
            //}

            Close();
        }

        private void ClickSaveButton(object sender, RoutedEventArgs e)
        {
            //if (!ChangeManager.GetInstance().IsChanged())
            //{
            //    MessageBox.Show("Nothing Changed.");
            //    return;
            //}
            StartProgressBar();
            //ChangeManager.GetInstance().Save();
            StopProgressBar();
        }

        private void SaveAnElement(XElement rootXe)
        {
            //XAttribute idAttr = rootXe.Attribute(ConstString.AttributeId);
            //if (idAttr != null)
            //{
            //    string id = idAttr.Value;
            //    string content = rootXe.ToString(SaveOptions.None);
            //    _client.UpdateData(id, content);
            //}
        }

        private void ClickOpenButton(object sender, RoutedEventArgs e)
        {
            //TODO load the workflow from server
        }

        private void ClickNewButton(object sender, RoutedEventArgs e)
        {
            //TODO just for test now, will update to more complex logic

            string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetTempFileName());
            var newTestSuite = new ActivityLib.TestSuite { DisplayName = "new Test suite without name" };
            //var newTestSuite = new Sequence();
            XamlServices.Save(fileName, newTestSuite);
            AddDesigner(fileName);            
        }

        private void ClickUndoButton(object sender, RoutedEventArgs e)
        {
            redoMenu.IsEnabled = true;
            _workflowDesigner.Context.Services.GetService<UndoEngine>().Undo();
            if (_undoEngineService.GetUndoActions().Count() == 0)
                undoMenu.IsEnabled = false;
            if (_undoEngineService.GetRedoActions().Count() > 0)
                redoMenu.IsEnabled = true;
        }

        private void ClickRedoButton(object sender, RoutedEventArgs e)
        {
            _workflowDesigner.Context.Services.GetService<UndoEngine>().Redo();
            if (_undoEngineService.GetRedoActions().Count() == 0)
                redoMenu.IsEnabled = false;
            if (_undoEngineService.GetUndoActions().Count() > 0)
                undoMenu.IsEnabled = true;
        }

        #endregion Main Menu

        private void ProjectContextMenuOpened(object sender, RoutedEventArgs e)
        {
            //ContextMenuOpened(ProjectTreeView);
        }

        private void DataContextMenuOpened(object sender, RoutedEventArgs e)
        {
            //ContextMenuOpened(DataTree);
        }

        private void GuiObjectsContextMenuOpened(object sender, RoutedEventArgs e)
        {
            //ContextMenuOpened(GuiObjectTree);
        }

        private void ProjectTreeDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //DoubleClickOnTree(ProjectTreeView);
        }

        private void DataTreeDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //DoubleClickOnTree(DataTree);
        }

        private void GuiTreeDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //DoubleClickOnTree(GuiObjectTree);
        }

        private void ProjectTreeMenuItemClicked(object sender, RoutedEventArgs e)
        {
            var tag = (string)((MenuItem)sender).Tag;
            TreeView currentTree = ProjectTreeView;

            if (currentTree.SelectedItem == null)
                return;
            //UpdateAndDeleteAndReload(currentTree, tag);

            //if (!tag.Equals("Delete") && !tag.Equals("Update") && !tag.Equals("Reload"))
            //{
            //    XElement toCreatedXe;
            //    if (tag.Equals("Project"))
            //        toCreatedXe = _template.CreateProject(_userName);
            //    else
            //        toCreatedXe = _template.GetInitalObject(tag, _userName);

            //    if (tag.Equals("TestSuite")
            //        || tag.Equals("TestCase")
            //        || tag.Equals("TestSteps"))
            //    {
            //        CreateActivity(toCreatedXe);
            //    }

            //    var tvi = new XElementTreeViewItem(toCreatedXe);
            //    ((XElementTreeViewItem)currentTree.SelectedItem).Add(tvi.GetSimpleVersion());
            //    ChangeManager.GetInstance().Changed(toCreatedXe);
            //    ChangeManager.GetInstance().Changed(GetNearestIndependentParent((TreeViewItem)currentTree.SelectedItem).Element);
            //}

            //currentTree.UpdateLayout();
        }

        private void DataTreePreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(null);
        }

        private void DataTreePreviewMouseMove(object sender, MouseEventArgs e)
        {
            // Get the current mouse position
            System.Windows.Point mousePos = e.GetPosition(null);
            Vector diff = _startPoint - mousePos;

            DragTreeviewItem(e, diff, "DataFormat");
        }

        private void GuiObjectsTreeMenuItemClicked(object sender, RoutedEventArgs e)
        {
            var tag = (string)((MenuItem)sender).Tag;
            TreeView currentTree = GuiObjectTree;
            if (currentTree.SelectedItem == null)
                return;
            //UpdateAndDeleteAndReload(currentTree, tag);

            //if (!tag.Equals("Delete") && !tag.Equals("Update") && !tag.Equals("Reload"))
            //{
            //    XElement toCreateXe = AddNodeByTemplete(currentTree, tag);
            //}
        }

        private void DataTreeMenuItemClicked(object sender, RoutedEventArgs e)
        {
            var tag = (string)((MenuItem)sender).Tag;
            TreeView currentTree = DataTree;
            if (currentTree.SelectedItem == null)
                return;
            //UpdateAndDeleteAndReload(currentTree, tag);

            //if (!tag.Equals("Delete") && !tag.Equals("Update") && !tag.Equals("Reload"))
            //{
            //    XElement toCreateXe = AddNodeByTemplete(currentTree, tag);
            //}
        }

    }
}