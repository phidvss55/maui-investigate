using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Repository;
using Contact = MauiApp1.Model.Contact;

namespace MauiApp1.Pages;

public partial class AddContactPage : ContentPage
{
    public AddContactPage()
    {
        InitializeComponent();
    }

    private void OnSaveButtonClicked(object? sender, EventArgs e)
    {
        ContactRepository.AddContact(new Contact
        {
            Name = contactCtl.Name,
            Email = contactCtl.Email,
            Phone = contactCtl.Phone
        });
    }

    private void OnBackButtonClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void ContactCtl_OnOnError(object? sender, string e)
    {
        DisplayAlertAsync("Error", e, "OK");
    }
}