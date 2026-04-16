# MauiApp1 - iOS Only Configuration

This project has been configured to run **iOS only** with the following setup:

## 📋 Project Configuration

- **Target Framework**: `net10.0-ios`
- **Runtime Identifier**: `ios-arm64`
- **Minimum iOS Version**: 15.0
- **XAML Compilation**: Source-generated (SourceGen)

## 🚀 Running on iOS Simulator

### Prerequisites
- macOS with Xcode installed
- .NET 10.0 SDK
- iOS Simulator (via Xcode)

### Steps to Run

#### 1. **Build the project**
```bash
cd /Users/dinhphi/Documents/Dev/dotnet/MauiApp1/MauiApp1
dotnet build -c Debug -f net10.0-ios
```

#### 2. **List available iOS simulators**
```bash
xcrun simctl list devices available
```

#### 3. **Boot a simulator** (if not already running)
```bash
xcrun simctl boot "iPhone 15"  # or any available device
```

#### 4. **Run the app on simulator**
```bash
dotnet build -t:Run -c Debug -f net10.0-ios
```

Or alternatively:
```bash
dotnet build -c Debug -f net10.0-ios
dotnet msbuild -t:Run -p:Configuration=Debug -p:TargetFramework=net10.0-ios
```

#### 5. **Deploy to physical device**

First, configure code signing in the project:
```bash
# You may need to set your team ID in MauiApp1.csproj:
# <BundleIdentifier>com.companyname.mauiapp1</BundleIdentifier>
# <SigningKey>iPhone Developer</SigningKey>
# <TeamId>YOUR_TEAM_ID</TeamId>
```

Then connect your device and run:
```bash
dotnet build -c Release -f net10.0-ios
```

## 📁 Project Structure (iOS-focused)

```
MauiApp1/
├── MauiApp1.csproj              # iOS-only configuration
├── App.xaml & App.xaml.cs       # Main application entry
├── AppShell.xaml                # Shell navigation setup
├── MainPage.xaml & .cs          # Login UI (fixed with modern MAUI patterns)
├── MauiProgram.cs              # MAUI app builder
├── Platforms/
│   └── iOS/
│       ├── Program.cs           # iOS entry point
│       ├── AppDelegate.cs       # iOS app delegate
│       └── Info.plist           # iOS configuration
└── Resources/
    ├── AppIcon/                 # App icons
    ├── Fonts/                   # Custom fonts
    └── Images/                  # App images
```

## 🔧 Project File Configuration

The `MauiApp1.csproj` has been simplified to iOS-only:

```xml
<TargetFramework>net10.0-ios</TargetFramework>
<RuntimeIdentifier>ios-arm64</RuntimeIdentifier>
```

This removes multi-platform configuration complexity and speeds up builds.

## 📱 App Features

### MainPage (Login Screen)
- **Layout**: Modern Grid + VerticalStackLayout
- **Properties Used**: `Background` (not deprecated BackgroundColor)
- **Bindings**: Compiled bindings with proper nullability
- **Event Handling**: Button click with UI feedback

### Navigation
- Using Shell navigation pattern (recommended)
- Single entry point via `AppShell.xaml`

## ⚙️ Build Configurations

### Debug Build
```bash
dotnet build -c Debug
```
- Includes debug symbols
- Logging enabled
- Faster compilation

### Release Build
```bash
dotnet build -c Release
```
- Optimized for performance
- Ready for App Store submission
- Smaller app size

## 🐛 Troubleshooting

### Build fails with "iOS SDK not found"
- Ensure Xcode is installed: `xcode-select --install`
- Update Xcode if necessary

### Simulator won't start
```bash
xcrun simctl erase all  # Reset all simulators
xcrun simctl boot "iPhone 15"  # Boot fresh simulator
```

### App crashes on launch
1. Check console output: `Console.app`
2. Look for errors in the build output
3. Verify all XAML files have correct bindings

### Code signing errors on device
1. Go to Xcode > Preferences > Accounts
2. Add your Apple ID
3. Update the TeamId in MauiApp1.csproj

## 📚 Modern MAUI Best Practices Used

✅ **Background** instead of deprecated BackgroundColor  
✅ **Grid** for layout hierarchy  
✅ **Proper nullability** in event handlers  
✅ **Shell navigation** over NavigationPage  
✅ **XAML source generation** for performance  
✅ **Compiled bindings** with x:DataType  

## 🔗 Useful Resources

- [Microsoft MAUI Documentation](https://learn.microsoft.com/dotnet/maui/)
- [iOS Deployment](https://learn.microsoft.com/dotnet/maui/ios/deployment/)
- [Handlers Instead of Renderers](https://learn.microsoft.com/dotnet/maui/user-interface/handlers/)

---

**Ready to build!** Use the commands above to get your iOS app running. 🎉
