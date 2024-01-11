.PHONY: all libSpiderStream ServerExample clean

all: libSpiderStream ServerExample

libSpiderStream:
	$(MAKE) -C libSpiderStream

ServerExample: libSpiderStream
	$(MAKE) -C ServerExample

clean:
	$(MAKE) -C libSpiderStream clean
	$(MAKE) -C ServerExample clean
