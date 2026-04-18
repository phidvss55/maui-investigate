.PHONY: build debug check-avai boot-ios-debug release

build:
	dotnet build -c Debug -f net10.0-ios

debug:
	dotnet build -t:Run -c Debug -f net10.0-ios

check-avai:
	xcrun simctl list devices available

boot-ios-debug:
	xcrun simctl boot "iPhone 16 Pro"

release:
	dotnet build -c Release -f net10.0-ios