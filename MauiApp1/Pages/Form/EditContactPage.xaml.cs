using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Repository;
using Contact = MauiApp1.Model.Contact;

namespace MauiApp1.Pages;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Contact contact;

    public EditContactPage()
    {
        InitializeComponent();
    }

    public void OnBackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    public string ContactId
    {
        set
        {
            contact = ContactRepository.GetContactById(int.Parse(value));
            // lblName.Text = contact.Name;
            if (contact.Name != null)
            {
                contactCtl.Name = contact.Name;
                contactCtl.Email = contact.Email;
                contactCtl.Phone = contact.Phone;

            }
        }
    }
    
    public async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        contact.Name = contactCtl.Name;
        contact.Email = contactCtl.Email;
        contact.Phone = contactCtl.Phone;

        ContactRepository.UpdateContact(contact.ContactId, contact);
        await DisplayAlertAsync("Success", "Contact updated successfully", "OK");
        await Shell.Current.GoToAsync("..");
    }

    private void ContactCtl_OnOnError(object? sender, string e)
    {
        DisplayAlertAsync("Error", e, "OK");
    }
}