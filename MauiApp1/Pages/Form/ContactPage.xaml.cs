using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MauiApp1.Repository;
using Contact = MauiApp1.Model.Contact;

namespace MauiApp1.Pages;

public partial class ContactPage : ContentPage
{
    public ObservableCollection<Contact> Items { get; } = new();
    private readonly HashSet<int> _selectedContactIds = new();
    private bool _isCheckBoxInteraction;

    public ContactPage()
    {
        InitializeComponent();
        BindingContext = this;
        LoadContacts();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadContacts();
    }

    private void LoadContacts()
    {
        Items.Clear();
        foreach (var contact in ContactRepository.GetContacts())
        {
            Items.Add(contact);
        }

        _selectedContactIds.Clear();
        UpdateDeleteButtonState();

        if (ContactsCollectionView != null)
        {
            ContactsCollectionView.SelectedItem = null;
        }
    }

    private void BtnEditContact_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditContactPage));
    }

    private void BtnAddContact_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private async void SelectableItemsView_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (_isCheckBoxInteraction)
        {
            if (sender is CollectionView collectionView)
            {
                collectionView.SelectedItem = null;
            }

            return;
        }

        if (e.CurrentSelection.FirstOrDefault() is Model.Contact contact)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={contact.ContactId}");

            if (sender is CollectionView collectionView)
            {
                collectionView.SelectedItem = null;
            }
        }
    }

    private void ContactCheckBox_OnCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        if (sender is not CheckBox checkBox || checkBox.BindingContext is not Contact contact)
        {
            return;
        }

        _isCheckBoxInteraction = true;

        if (e.Value)
        {
            _selectedContactIds.Add(contact.ContactId);
        }
        else
        {
            _selectedContactIds.Remove(contact.ContactId);
        }

        UpdateDeleteButtonState();

        Dispatcher.Dispatch(() => _isCheckBoxInteraction = false);
    }

    private async void BtnDeleteContact_OnClicked(object? sender, EventArgs e)
    {
        if (_selectedContactIds.Count == 0)
        {
            return;
        }

        var canDelete = await DisplayAlertAsync(
            "Delete Contacts",
            $"Delete {_selectedContactIds.Count} selected contact(s)?",
            "Delete",
            "Cancel");

        if (!canDelete)
        {
            return;
        }

        foreach (var contactId in _selectedContactIds.ToList())
        {
            ContactRepository.DeleteContact(contactId);
        }

        LoadContacts();
    }

    private void UpdateDeleteButtonState()
    {
        if (btnDeleteContact == null)
        {
            return;
        }

        var count = _selectedContactIds.Count;
        btnDeleteContact.IsEnabled = count > 0;
        btnDeleteContact.Text = count > 0 ? $"Delete Selected ({count})" : "Delete Selected";
    }

    private void InputView_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        if (sender is not SearchBar searchBar)
        {
            return;
        }

        var query = searchBar.Text?.Trim().ToLower() ?? string.Empty;

        var filteredContacts = ContactRepository.GetContacts()
            .Where(c => c.Name.ToLower().Contains(query) || c.Phone.Contains(query))
            .ToList();

        Items.Clear();
        foreach (var contact in filteredContacts)
        {
            Items.Add(contact);
        }
    }

    private void SearchBar_OnSearchButtonPressed(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}
