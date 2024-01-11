#### PROJECT SETTINGS ####
BIN_NAME := libSpiderStream
CXX ?= g++
SRC_EXT = cpp
SRC_PATH = ../src
INCLUDES = -I ../include -I ../externals/websocketpp
COMPILE_FLAGS = -std=c++11 -Wall -Wextra -fpic 
RCOMPILE_FLAGS = -O2
DCOMPILE_FLAGS = -g -D DEBUG
LINK_FLAGS = -shared -Wl,-soname,$(BIN_NAME).so
LIBRARY_PATH = ../lib
DEP_FLAGS = -MMD -MP

#### END PROJECT SETTINGS ####

# Find source files
SOURCES = $(shell find $(SRC_PATH) -name '*.$(SRC_EXT)')
OBJECTS_RELEASE = $(SOURCES:$(SRC_PATH)/%.$(SRC_EXT)=build/release/%.o)
OBJECTS_DEBUG = $(SOURCES:$(SRC_PATH)/%.$(SRC_EXT)=build/debug/%.o)
DEPS = $(OBJECTS_RELEASE:.o=.d) $(OBJECTS_DEBUG:.o=.d)

# Build targets
.PHONY: all release debug clean

all: release debug

release: update_submodules $(LIBRARY_PATH)/$(BIN_NAME).so

debug: update_submodules $(LIBRARY_PATH)/$(BIN_NAME)_debug.so

$(LIBRARY_PATH)/$(BIN_NAME).so: $(OBJECTS_RELEASE)
	mkdir -p $(LIBRARY_PATH)
	$(CXX) $(CXXFLAGS) $(COMPILE_FLAGS) $(RCOMPILE_FLAGS) $(INCLUDES) $(LINK_FLAGS) -o $@ $(OBJECTS_RELEASE)

$(LIBRARY_PATH)/$(BIN_NAME)_debug.so: $(OBJECTS_DEBUG)
	mkdir -p $(LIBRARY_PATH)
	$(CXX) $(CXXFLAGS) $(COMPILE_FLAGS) $(DCOMPILE_FLAGS) $(INCLUDES) $(LINK_FLAGS) -o $@ $(OBJECTS_DEBUG)

build/release/%.o: $(SRC_PATH)/%.$(SRC_EXT)
	mkdir -p $(@D)
	$(CXX) $(CXXFLAGS) $(COMPILE_FLAGS) $(RCOMPILE_FLAGS) $(INCLUDES) $(DEP_FLAGS) -c $< -o $@

build/debug/%.o: $(SRC_PATH)/%.$(SRC_EXT)
	mkdir -p $(@D)
	$(CXX) $(CXXFLAGS) $(COMPILE_FLAGS) $(DCOMPILE_FLAGS) $(INCLUDES) $(DEP_FLAGS) -c $< -o $@

update_submodules:
	git submodule update --init --recursive

clean:
	rm -rf build $(LIBRARY_PATH)/$(BIN_NAME)*

-include $(DEPS)

