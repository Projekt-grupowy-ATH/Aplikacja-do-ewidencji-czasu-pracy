package com.example.nfcmodule

import android.nfc.cardemulation.HostApduService
import android.os.Bundle

class ApduService : HostApduService() {

    override fun processCommandApdu(commandApdu: ByteArray, extras: Bundle?): ByteArray {
        val UserID: String = "1234532"
        // Bellow employer ID for remote device
        var response: ByteArray = UserID.toByteArray()
        return response
    }

    override fun onDeactivated(reason: Int) {

    }
}