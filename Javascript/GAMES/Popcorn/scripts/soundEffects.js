function playSingleSound(targetSound) {
    switch (targetSound) {
        case 'explosionSound':
            document.getElementById('explosionSound').play();
            break;
        case 'paddleReflectionSound':
            document.getElementById('paddleReflectionSound').play();
            break;
        default:
    }
}
