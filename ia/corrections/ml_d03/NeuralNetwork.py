from Neuron import *

class NeuralNetwork:
    def __init__(self, layerDescriptor):
        self.layers = [[Neuron(0) for i in range(layerDescriptor[0])]]
        for i in range(1, len(layerDescriptor)):
            self.layers.append([Neuron(layerDescriptor[i - 1]) for j in range(layerDescriptor[i])])

    def activate(self, entries):
        for i in range(len(entries)):
            self.layers[0][i].out = entries[i] # Initialize entry layer with entries values
        for i in range(1, len(self.layers)): # For each layer
            for j in range(0, len(self.layers[i])): # For each neuron of this layer
                self.layers[i][j].activateWithLayer(self.layers[i - 1]) # Compute the neuron

    def getOutputs(self):
        out = []
        for i in self.layers[len(self.layers) - 1]:
            out.append(i.out)
        return out
