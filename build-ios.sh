#!/bin/bash

# MauiApp1 iOS Build & Run Script
# This script helps build and run the iOS app on simulator or device

set -e

PROJECT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )/MauiApp1"
CONFIGURATION="${1:-Debug}"

echo "🚀 MauiApp1 iOS Build Script"
echo "================================"
echo "Configuration: $CONFIGURATION"
echo "Project: $PROJECT_DIR"
echo ""

# Check if dotnet is available
if ! command -v dotnet &> /dev/null; then
    echo "❌ Error: dotnet CLI not found. Please install .NET 10.0 SDK"
    exit 1
fi

# Build the project
echo "📦 Building iOS app (net10.0-ios)..."
cd "$PROJECT_DIR"
dotnet build -c "$CONFIGURATION" -f net10.0-ios

if [ $? -eq 0 ]; then
    echo ""
    echo "✅ Build completed successfully!"
    echo ""
    echo "📱 Next steps:"
    echo "   • To run on simulator: dotnet build -t:Run -c $CONFIGURATION -f net10.0-ios"
    echo "   • To list simulators: xcrun simctl list devices available"
    echo "   • To boot simulator: xcrun simctl boot 'iPhone 15'"
    echo ""
else
    echo "❌ Build failed. Check errors above."
    exit 1
fi
