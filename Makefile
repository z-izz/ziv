CSC=dotnet
projname=ziv
tgtversion=7.0
tgtsys=linux-x64
bin=bin/Debug/net$(tgtversion)/$(tgtsys)/publish/$(projname)
CSC_flags=-r $(tgtsys) --self-contained false
all: file
build:
	@ echo Building $(projname)...
	$(CSC) build $(CSC_flags)

file:
	@ echo Building $(projname) into one file...
	$(CSC) publish -r $(tgtsys) -p:PublishSingleFile=true --self-contained false

run:
	@ $(bin)
install:
	@ echo Installing ziv into /bin/ziv
	sudo cp $(bin) /bin/$(projname)
