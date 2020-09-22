all : clean restore build publish

clean:
	dotnet clean

restore:
	dotnet restore

build: 
	dotnet build

publish:
	dotnet publish -c Release -r linux-x64
	# https://github.com/dgiagio/warp - create single executable file
	mkdir -p bin/single/
	warp-packer --arch linux-x64 --input_dir bin/Release/netcoreapp3.1/linux-x64/publish --exec HelloWorld --output bin/single/HelloWorld

run:
	dotnet run
