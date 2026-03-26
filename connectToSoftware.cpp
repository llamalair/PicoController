#include <stdio.h>
#include "pico/stdlib.h"
#include "pico/stdio_usb.h" // allow you to use the usb seriel 

void pico_set_led(bool led_on){ // allow it to set as 1 or 0 
    gpio_put(25,led_on);
}


int main()
{
    stdio_init_all();
    gpio_init(25); // initiase the gpio pin 
    gpio_set_dir(25,GPIO_OUT); // set the program to output 
    gpio_put(25,0); // start of as OFF 

    while (true){
        int user_input = getchar();

        if (user_input == '1' ){
            pico_set_led(true);
        }
        else if (user_input == '0'){
            pico_set_led(false);
        }
    }
}
