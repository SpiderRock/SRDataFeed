#### PROJECT SETTINGS ####
BIN_NAME := ServerExample
CXX ?= g++
SRC_EXT = cpp
SRC_PATH = ../examples/ServerExample
COMPILE_FLAGS = -std=c++11 -Wall -Wextra
RCOMPILE_FLAGS = -O2
DCOMPILE_FLAGS = -g -D DEBUG
INCLUDES = -I ../include
LINK_FLAGS = -L ../lib -lrt -pthread -lSpiderStream -Wl,-rpath,../lib
LIB_NAME = SpiderStream

#### END PROJECT SETTINGS ####

# Find source files
SOURCES = $(shell find $(SRC_PATH) -name '*.$(SRC_EXT)')
OBJECTS_RELEASE = $(SOURCES:$(SRC_PATH)/%.$(SRC_EXT)=build/release/%.o)
OBJECTS_DEBUG = $(SOURCES:$(SRC_PATH)/%.$(SRC_EXT)=build/debug/%.o)

# Build targets
.PHONY: all release debug clean

all: release debug

release: $(BIN_NAME)

debug: $(BIN_NAME)_debug

$(BIN_NAME): $(OBJECTS_RELEASE)
	$(CXX) $(OBJECTS_RELEASE) $(CXXFLAGS) $(COMPILE_FLAGS) $(RCOMPILE_FLAGS) $(INCLUDES) $(LINK_FLAGS) -l$(LIB_NAME) -o $@

$(BIN_NAME)_debug: $(OBJECTS_DEBUG)
	$(CXX) $(OBJECTS_DEBUG) $(CXXFLAGS) $(COMPILE_FLAGS) $(DCOMPILE_FLAGS) $(INCLUDES) $(LINK_FLAGS) -l$(LIB_NAME) -o $@

build/release/%.o: $(SRC_PATH)/%.$(SRC_EXT)
	mkdir -p $(@D)
	$(CXX) $(CXXFLAGS) $(COMPILE_FLAGS) $(RCOMPILE_FLAGS) $(INCLUDES) -c $< -o $@

build/debug/%.o: $(SRC_PATH)/%.$(SRC_EXT)
	mkdir -p $(@D)
	$(CXX) $(CXXFLAGS) $(COMPILE_FLAGS) $(DCOMPILE_FLAGS) $(INCLUDES) -c $< -o $@

clean:
	rm -rf build $(BIN_NAME)*
