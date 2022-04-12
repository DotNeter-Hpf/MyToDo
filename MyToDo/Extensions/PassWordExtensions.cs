using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyToDo.Extensions
{
    public class PassWordExtensions
    {
        // propa 使用附加属性的快捷键

        public static string GetPassWord(DependencyObject obj)
        {
            return (string)obj.GetValue(PassWordProperty);
        }


        public static void SetPassWord(DependencyObject obj, string value)
        {
            obj.SetValue(PassWordProperty, value);
        }


        public static readonly DependencyProperty PassWordProperty =
            DependencyProperty.RegisterAttached("PassWord", typeof(string), typeof(PassWordExtensions), new PropertyMetadata(string.Empty, OnPassWordPropertyChanged));


        private static void OnPassWordPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var passWord = sender as PasswordBox;
            string password = (string)e.NewValue;
            if (passWord != null && passWord.Password != password)
            {
                passWord.Password = password;
            }
        }
    }

    public class PassWordBehavior : Behavior<PasswordBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PasswordChanged += AssociatedObject_PasswordChanged;
        }


        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

        private void AssociatedObject_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            string password = PassWordExtensions.GetPassWord(passwordBox);

            if (passwordBox != null && passwordBox.Password != password)
            {
                PassWordExtensions.SetPassWord(passwordBox, passwordBox.Password);
            }
        }
    }
}
