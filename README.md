# OneTimePad Algorithm

This project implements the One-Time Pad encryption algorithm in C#. The One-Time Pad is a symmetric encryption technique that uses a random key, known as the one-time pad, to encrypt and decrypt messages. Please note that this implementation is provided for educational purposes only and may not have all the necessary security features for production use.

## Getting Started

To run the project, follow these steps:

    1. Ensure you have the .NET Framework installed on your machine.
    2. Clone or download the project files.
    3. Open the project in your preferred C# development environment.
    4. Build and run the project.

## How It Works

The One-Time Pad algorithm works as follows:

    1. Define a character set that will be used for encryption.
    2. Generate a random key with the same length as the message to be encrypted.
    3. Convert the message and the key to their respective numeric representations based on the character set.
    4. Perform modular addition of each character in the message with the corresponding character in the key, using the character set size as the modulus.
    5. Convert the resulting encrypted characters back to their corresponding characters from the character set.
    6. The encrypted message and the key are returned.

To decrypt the message, the same key is used to perform modular subtraction instead of addition.

## Usage
    1. Define the character set to be used for encryption in the `Characters` constant.
    2. In the `Main` method, call the `Encrypt` function, passing the message and the character-to-index mapping.
    3. The `Encrypt` function will return an array containing the encrypted message and the key.
    4. Display the encrypted message.
    5. Call the `Decrypt` function, passing the encrypted message, the key, and the character-to-index mapping.
    6. The `Decrypt` function will return the decrypted message.
    7. Display the decrypted message.

## Security Considerations

The One-Time Pad algorithm, when used correctly, provides perfect secrecy. However, there are several important considerations to keep in mind:

1. **Key Generation**: The security of the One-Time Pad depends on using a truly random and unpredictable key. In this implementation, random bytes are generated using the `RandomNumberGenerator` class. However, it is crucial to ensure that the random number generator used is of high quality and adequately seeded.
2. **Key Management**: Each key should only be used once and should be at least as long as the message to be encrypted. It is essential to securely store and transmit the keys to maintain the security of the system.
3. **Character Set**: The character set used for encryption should include all the characters required in the messages to be encrypted. Ensure that the character set is appropriate for the application and aligns with the intended use.
4. **Message Length**: The length of the message and the key should be the same. If the message is shorter than the key, it should be padded or truncated accordingly.
5. **Secure Communication**: The One-Time Pad algorithm does not address secure communication of the key. It assumes that the key is securely exchanged between the communicating parties. It is essential to use secure communication channels to transmit the key to maintain the security of the system.
6. **Cryptanalysis**: The security of the One-Time Pad algorithm relies on the secrecy and uniqueness of the key. If the key is compromised or reused, the security of the encryption can be compromised. It is crucial to follow best practices for key generation, distribution, and management to mitigate the risk of cryptanalysis attacks.

## Conclusion

The One-Time Pad algorithm provides a secure encryption method when used correctly. This project demonstrates the implementation of the One-Time Pad algorithm in C#, allowing you to understand the basic principles and mechanisms behind this encryption technique. However, it is important to consider the security considerations mentioned above and consult cryptographic experts or established libraries for secure encryption requirements.

## References
https://de.wikipedia.org/wiki/One-Time-Pad
<br>
https://youtu.be/nKEKDS0epKw
