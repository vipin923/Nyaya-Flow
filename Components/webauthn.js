window.webauthn = {
    // This prompts the user to insert their USB Key (PenDrive) and touch it
    authenticate: async function (challengeOptions) {
        try {
            // The backend will send a cryptographically secure challenge
            const publicKeyCredentialRequestOptions = {
                challenge: Uint8Array.from(challengeOptions.challenge, c => c.charCodeAt(0)),
                allowCredentials: [{
                    id: Uint8Array.from(challengeOptions.credentialId, c => c.charCodeAt(0)),
                    type: 'public-key'
                }],
                timeout: 60000,
                userVerification: "preferred"
            };

            const assertion = await navigator.credentials.get({
                publicKey: publicKeyCredentialRequestOptions
            });

            // Return the assertion back to Blazor to verify on the .NET backend
            return {
                id: assertion.id,
                rawId: btoa(String.fromCharCode.apply(null, new Uint8Array(assertion.rawId))),
                type: assertion.type,
                // ClientDataJSON and AuthenticatorData would be mapped here in a full implementation
                success: true
            };
        } catch (error) {
            console.error("Hardware Key Error:", error);
            return { success: false, errorMessage: error.message };
        }
    }
};