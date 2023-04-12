CSC=dotnet
projname=ziv
tgtversion=7.0
tgtsys=linux-x64
bin=bin/Debug/net$(tgtversion)/$(tgtsys)/$(projname).dll
CSC_flags=-r $(tgtsys) --self-contained false
all: file
build:
	@ echo Building $(projname)...
	$(CSC) build $(CSC_flags)

file:
	@ echo Building $(projname) into one file...
	$(CSC) publish -r $(tgtsys) -p:PublishSingleFile=true --self-contained false

run:
	@ dotnet $(bin)