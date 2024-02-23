host=linux-x64
CSC=dotnet
projname=ziv
tgtversion=8.0
bin=bin/Release/net$(tgtversion)/$(host)/publish/$(projname)
all: multiplatform readytest

file:
	@ echo Building $(projname) into one file...
	$(CSC) publish -r $(host) -p:PublishSingleFile=true --self-contained false

multiplatform:
	@ echo Building $(projname) into one file, for both linux-x64 and win-x64 targets
	$(CSC) publish -r linux-x64 -p:PublishSingleFile=true --self-contained false
	$(CSC) publish -r win-x64 -p:PublishSingleFile=true --self-contained false

readytest:
	cp $(bin) .

run:
	@ $(bin)
install:
	@ echo Installing ziv into /bin/ziv
	sudo cp $(bin) /bin/$(projname)
