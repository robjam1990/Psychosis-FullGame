// "This is the updated neural network structure for Animals and NPC's."

using System.Collections.Generic;

public class NPC_NN
{
    // Object log for neural network information
    public Dictionary<string, object> OLog = new Dictionary<string, object>
    {
        // Output log containing layers and configurations
        { "Y", new List<string> { "top" } },
        {
            "modelTopology", new Dictionary<string, object>
            {
                // Class name indicating the neural network type
                { "class_name", "Neurological" },
                {
                    "config", new Dictionary<string, object>
                    {
                        // Name and type of model
                        { "name", "sequential" },
                        {
                            "layers", new List<Dictionary<string, object>>
                            {
                                // Layer details
                                new Dictionary<string, object>
                                {
                                    // Class name for layer type
                                    { "class_name", "Dense" },
                                    {
                                        "config", new Dictionary<string, object>
                                        {
                                            // Number of units in the layer
                                            { "units", 1 },
                                            // Activation function for the layer
                                            { "activation", "sigmoid" },
                                            // Whether to use bias in the layer
                                            { "use_bias", true },
                                            {
                                                // Initializer for kernel weights
                                                "kernel_initializer", new Dictionary<string, object>
                                                {
                                                    { "class_name", "VarianceScaling" },
                                                    {
                                                        "config", new Dictionary<string, object>
                                                        {
                                                            // Scaling factor for weights
                                                            { "scale", 1 },
                                                            // Mode for initializing weights
                                                            { "mode", "fan_avg" },
                                                            // Distribution for weight initialization
                                                            { "distribution", "normal" },
                                                            // Seed for random weight initialization
                                                            { "seed", null }
                                                        }
                                                    }
                                                }
                                            },
                                            {
                                                // Initializer for bias weights
                                                "bias_initializer", new Dictionary<string, object>
                                                {
                                                    { "class_name", "Zeros" },
                                                    { "config", new Dictionary<string, object>() }
                                                }
                                            },
                                            // Regularizer for kernel weights
                                            { "kernel_regularizer", null },
                                            // Regularizer for bias weights
                                            { "bias_regularizer", null },
                                            // Regularizer for activity
                                            { "activity_regularizer", null },
                                            // Constraint for kernel weights
                                            { "kernel_constraint", null },
                                            // Constraint for bias weights
                                            { "bias_constraint", null },
                                            // Name of the layer
                                            { "name", "dense_Dense35" },
                                            // Whether the layer is trainable
                                            { "trainable", true },
                                            // Shape of input data
                                            { "batch_input_shape", new List<object> { null, 10 } },
                                            // Data type for input data
                                            { "dtype", "float32" }
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                // Version of Keras used
                { "keras_version", "tfjs-layers 4.17.0" },
                // Backend used for computation
                { "backend", "matrix.js" }
            }
        },
        // Format of the neural network model
        { "format", "layers-model" },
        // Generated by information
        { "generatedBy", "self" },
        // Converted by information
        { "convertedBy", null },
        {
            // Manifest for weights of the neural network
            "weightsManifest", new List<Dictionary<string, object>>
            {
                new Dictionary<string, object>
                {
                    {
                        // Paths to weight files
                        "paths", new List<string>
                        {
                            "./mymodel.weights.bin"
                        }
                    },
                    {
                        // Details of weights
                        "weights", new List<Dictionary<string, object>>
                        {
                            new Dictionary<string, object>
                            {
                                // Name of kernel weights
                                { "name", "dense_Dense35/kernel" },
                                // Shape of kernel weights
                                { "shape", new List<int> { 10, 1 } },
                                // Data type of kernel weights
                                { "dtype", "float32" }
                            },
                            new Dictionary<string, object>
                            {
                                // Name of bias weights
                                { "name", "dense_Dense35/bias" },
                                // Shape of bias weights
                                { "shape", new List<int> { 1 } },
                                // Data type of bias weights
                                { "dtype", "float32" }
                            }
                        }
                    }
                }
            }
        }
    };
}
