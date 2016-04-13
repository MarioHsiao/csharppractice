﻿using DynamicDataTemplate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace DynamicDataTemplate
{
    public class ImgDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate OnePhotoTemplate { get; set; }
        public DataTemplate TwoPhotoTemplate { get; set; }
        public DataTemplate MorePhotoTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(System.Object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            var father = GetParentObject<GridView>(element, "PhotoGrid");
            var itemssource = father.ItemsSource as Img[];
            //if (element != null && item != null && item is Img[])
            if (father != null && itemssource != null)
            {
                if (itemssource.Length == 1)
                    return OnePhotoTemplate;
                else if (itemssource.Length == 2)
                    return TwoPhotoTemplate;
                else return MorePhotoTemplate;
            }
            return null;
        }
        public T GetParentObject<T>(DependencyObject obj, string name) where T : FrameworkElement
        {
            DependencyObject parent = VisualTreeHelper.GetParent(obj);
            while (parent != null)
            {
                if (parent is T && (((T)parent).Name == name | string.IsNullOrEmpty(name)))
                {
                    return (T)parent;
                }

                parent = VisualTreeHelper.GetParent(parent);
            }
            return null;
        }
    }
}
